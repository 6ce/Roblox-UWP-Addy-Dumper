using System;
using System.Collections.Generic;
using System.Linq;

namespace EyeStepPackage
{
	// Token: 0x02000009 RID: 9
	public class scanner
	{
		// Token: 0x06000064 RID: 100 RVA: 0x00010EFC File Offset: 0x0000F0FC
		private static bool compare_bytes(byte[] bytes, ref int at, byte[] aob, char[] mask, int size)
		{
			for (int i = 0; i < size; i++)
			{
				if (mask[i] == '.' && bytes[at + i] != aob[i])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00010F2C File Offset: 0x0000F12C
		public static List<int> scan(string aob, bool code = true, int align = 1, int endresult = 0, scanner.scancheck[] checks = null)
		{
			List<int> list = new List<int>();
			byte[] array = new byte[128];
			char[] array2 = new char[128];
			int i = 0;
			int num = 0;
			while (i < aob.Length)
			{
				if (aob[i] != ' ')
				{
					char[] array3 = new char[]
					{
						aob[i],
						aob[1 + i++]
					};
					if (array3[0] == '?' && array3[1] == '?')
					{
						array[num] = 0;
						array2[num++] = '?';
					}
					else
					{
						int num2 = 0;
						int num3 = 0;
						for (;;)
						{
							if (array3[num2] > '`')
							{
								num3 = (int)(array3[num2] - 'W');
							}
							else if (array3[num2] > '@')
							{
								num3 = (int)(array3[num2] - '7');
							}
							else if (array3[num2] >= '0')
							{
								num3 = (int)(array3[num2] - '0');
							}
							if (num2 != 0)
							{
								break;
							}
							num2++;
							byte[] array4 = array;
							int num4 = num;
							array4[num4] += (byte)(num3 * 16);
						}
						byte[] array5 = array;
						int num5 = num;
						array5[num5] += (byte)num3;
						array2[num++] = '.';
					}
				}
				i++;
			}
			int j;
			int num6;
			if (!code)
			{
				j = EyeStep.base_module + EyeStep.base_module_size;
				num6 = 1073741823;
			}
			else
			{
				j = EyeStep.base_module;
				num6 = EyeStep.base_module + EyeStep.base_module_size;
			}
			while (j < num6)
			{
				imports.MEMORY_BASIC_INFORMATION memory_BASIC_INFORMATION;
				imports.VirtualQueryEx(EyeStep.handle, j, out memory_BASIC_INFORMATION, 44U);
				if (memory_BASIC_INFORMATION.BaseAddress != 0)
				{
					if ((memory_BASIC_INFORMATION.State & 4096U) == 4096U && (memory_BASIC_INFORMATION.Protect & 1U) != 1U && (memory_BASIC_INFORMATION.Protect & 512U) != 512U && (memory_BASIC_INFORMATION.Protect & 256U) != 256U)
					{
						byte[] array6 = util.readBytes(j, memory_BASIC_INFORMATION.RegionSize);
						for (int k = 0; k < memory_BASIC_INFORMATION.RegionSize; k += align)
						{
							if (scanner.compare_bytes(array6, ref k, array, array2, array2.Length))
							{
								int item = j + k;
								if (checks == null)
								{
									list.Add(item);
								}
								else
								{
									int num7 = 0;
									foreach (scanner.scancheck scancheck in checks)
									{
										switch (scancheck.type)
										{
										case scanner.scanchecks.byte_equal:
											if ((uint)array6[k + scancheck.offset] == scancheck.small)
											{
												num7++;
											}
											break;
										case scanner.scanchecks.word_equal:
											if ((uint)BitConverter.ToUInt16(array6, k + scancheck.offset) == scancheck.small)
											{
												num7++;
											}
											break;
										case scanner.scanchecks.int_equal:
											if (BitConverter.ToUInt32(array6, k + scancheck.offset) == scancheck.small)
											{
												num7++;
											}
											break;
										case scanner.scanchecks.byte_notequal:
											if ((uint)array6[k + scancheck.offset] != scancheck.small)
											{
												num7++;
											}
											break;
										case scanner.scanchecks.word_notequal:
											if ((uint)BitConverter.ToUInt16(array6, k + scancheck.offset) != scancheck.small)
											{
												num7++;
											}
											break;
										case scanner.scanchecks.int_notequal:
											if (BitConverter.ToUInt32(array6, k + scancheck.offset) != scancheck.small)
											{
												num7++;
											}
											break;
										}
									}
									if (num7 == checks.Length)
									{
										list.Add(item);
									}
								}
								if (endresult > 0 && list.Count >= endresult)
								{
									break;
								}
							}
						}
					}
					j += memory_BASIC_INFORMATION.RegionSize;
				}
			}
			return list;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0001129C File Offset: 0x0000F49C
		public static string aobstring(string str)
		{
			string text = "";
			for (int i = 0; i < str.Length; i++)
			{
				byte b = (byte)str[i];
				text += EyeStep.to_str(b);
				if (i < str.Length - 1)
				{
					text += " ";
				}
			}
			return text;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000112F0 File Offset: 0x0000F4F0
		public static string ptrstring(int ptr)
		{
			string str = "";
			byte[] bytes = BitConverter.GetBytes(ptr);
			return str + EyeStep.to_str(bytes[0]) + EyeStep.to_str(bytes[1]) + EyeStep.to_str(bytes[2]) + EyeStep.to_str(bytes[3]);
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00011340 File Offset: 0x0000F540
		public static List<int> scan_xrefs(string str, int nresult = 0)
		{
			List<int> list = scanner.scan(scanner.aobstring(str), true, 4, nresult, null);
			if (list.Count > 0)
			{
				return scanner.scan(scanner.ptrstring(list.Last<int>()), true, 1, 0, null);
			}
			throw new Exception("No results found for string");
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00011388 File Offset: 0x0000F588
		public static List<int> scan_xrefs(int func)
		{
			List<int> list = new List<int>();
			imports.MEMORY_BASIC_INFORMATION memory_BASIC_INFORMATION = default(imports.MEMORY_BASIC_INFORMATION);
			int i = EyeStep.base_module;
			int num = EyeStep.base_module + EyeStep.base_module_size;
			while (i < num)
			{
				imports.VirtualQueryEx(EyeStep.handle, i, out memory_BASIC_INFORMATION, 44U);
				if (memory_BASIC_INFORMATION.Protect == 32U)
				{
					byte[] array = util.readBytes(i, memory_BASIC_INFORMATION.RegionSize);
					for (int j = 0; j < memory_BASIC_INFORMATION.RegionSize; j++)
					{
						if ((array[j] == 232 || array[j] == 233) && util.getRel(i + j) == func)
						{
							list.Add(i + j);
						}
					}
				}
				i += memory_BASIC_INFORMATION.RegionSize;
			}
			return list;
		}

		// Token: 0x02000015 RID: 21
		public enum scanchecks
		{
			// Token: 0x04000133 RID: 307
			byte_equal,
			// Token: 0x04000134 RID: 308
			word_equal,
			// Token: 0x04000135 RID: 309
			int_equal,
			// Token: 0x04000136 RID: 310
			byte_notequal,
			// Token: 0x04000137 RID: 311
			word_notequal,
			// Token: 0x04000138 RID: 312
			int_notequal
		}

		// Token: 0x02000016 RID: 22
		public struct scancheck
		{
			// Token: 0x06000079 RID: 121 RVA: 0x000121A8 File Offset: 0x000103A8
			public scancheck(scanner.scanchecks _type, int _offset, uint _small)
			{
				this.type = _type;
				this.offset = _offset;
				this.small = _small;
				this.large = 0UL;
			}

			// Token: 0x04000139 RID: 313
			public scanner.scanchecks type;

			// Token: 0x0400013A RID: 314
			public int offset;

			// Token: 0x0400013B RID: 315
			public uint small;

			// Token: 0x0400013C RID: 316
			public ulong large;
		}
	}
}
