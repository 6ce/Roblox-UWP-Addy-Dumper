using System;
using System.Collections.Generic;
using System.Threading;

namespace EyeStepPackage
{
	// Token: 0x02000008 RID: 8
	public class util
	{
		// Token: 0x0600002F RID: 47 RVA: 0x0000FC50 File Offset: 0x0000DE50
		public static uint setPageProtect(int address, uint protect, int size = 1023)
		{
			uint result = 0U;
			imports.VirtualProtectEx(EyeStep.handle, address, size, protect, ref result);
			return result;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x0000FC70 File Offset: 0x0000DE70
		public static uint getPageProtect(int address)
		{
			imports.MEMORY_BASIC_INFORMATION memory_BASIC_INFORMATION = default(imports.MEMORY_BASIC_INFORMATION);
			imports.VirtualQueryEx(EyeStep.handle, address, out memory_BASIC_INFORMATION, 44U);
			return memory_BASIC_INFORMATION.Protect;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x0000FC9C File Offset: 0x0000DE9C
		public static void writeByte(int address, byte value)
		{
			byte[] array = new byte[]
			{
				value
			};
			imports.WriteProcessMemory(EyeStep.handle, address, array, array.Length, ref util.nothing);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x0000FCC9 File Offset: 0x0000DEC9
		public static void writeBytes(int address, byte[] bytes, int count = -1)
		{
			imports.WriteProcessMemory(EyeStep.handle, address, bytes, (count == -1) ? bytes.Length : count, ref util.nothing);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x0000FCE8 File Offset: 0x0000DEE8
		public static void writeShort(int address, short value)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			imports.WriteProcessMemory(EyeStep.handle, address, bytes, 2, ref util.nothing);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x0000FD10 File Offset: 0x0000DF10
		public static void writeUShort(int address, ushort value)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			imports.WriteProcessMemory(EyeStep.handle, address, bytes, 2, ref util.nothing);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x0000FD38 File Offset: 0x0000DF38
		public static void writeInt(int address, int value)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			imports.WriteProcessMemory(EyeStep.handle, address, bytes, 4, ref util.nothing);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x0000FD60 File Offset: 0x0000DF60
		public static void writeUInt(int address, uint value)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			imports.WriteProcessMemory(EyeStep.handle, address, bytes, 4, ref util.nothing);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000FD88 File Offset: 0x0000DF88
		public static void writeFloat(int address, float value)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			imports.WriteProcessMemory(EyeStep.handle, address, bytes, 4, ref util.nothing);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x0000FDB0 File Offset: 0x0000DFB0
		public static void writeDouble(int address, double value)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			imports.WriteProcessMemory(EyeStep.handle, address, bytes, 8, ref util.nothing);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x0000FDD8 File Offset: 0x0000DFD8
		public static byte readByte(int address)
		{
			byte[] array = new byte[1];
			imports.ReadProcessMemory(EyeStep.handle, address, array, 1, ref util.nothing);
			return array[0];
		}

		// Token: 0x0600003A RID: 58 RVA: 0x0000FE04 File Offset: 0x0000E004
		public static byte[] readBytes(int address, int count)
		{
			byte[] array = new byte[count];
			imports.ReadProcessMemory(EyeStep.handle, address, array, count, ref util.nothing);
			return array;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x0000FE2C File Offset: 0x0000E02C
		public static short readShort(int address)
		{
			byte[] array = new byte[2];
			imports.ReadProcessMemory(EyeStep.handle, address, array, 2, ref util.nothing);
			return BitConverter.ToInt16(array, 0);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x0000FE5C File Offset: 0x0000E05C
		public static ushort readUShort(int address)
		{
			byte[] array = new byte[2];
			imports.ReadProcessMemory(EyeStep.handle, address, array, 2, ref util.nothing);
			return BitConverter.ToUInt16(array, 0);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x0000FE8C File Offset: 0x0000E08C
		public static int readInt(int address)
		{
			byte[] array = new byte[4];
			imports.ReadProcessMemory(EyeStep.handle, address, array, 4, ref util.nothing);
			return BitConverter.ToInt32(array, 0);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x0000FEBC File Offset: 0x0000E0BC
		public static uint readUInt(int address)
		{
			byte[] array = new byte[4];
			imports.ReadProcessMemory(EyeStep.handle, address, array, 4, ref util.nothing);
			return BitConverter.ToUInt32(array, 0);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x0000FEEC File Offset: 0x0000E0EC
		public static float readFloat(int address)
		{
			byte[] array = new byte[4];
			imports.ReadProcessMemory(EyeStep.handle, address, array, 4, ref util.nothing);
			return BitConverter.ToSingle(array, 0);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x0000FF1C File Offset: 0x0000E11C
		public static double readDouble(int address)
		{
			byte[] array = new byte[8];
			imports.ReadProcessMemory(EyeStep.handle, address, array, 8, ref util.nothing);
			return BitConverter.ToDouble(array, 0);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x0000FF4C File Offset: 0x0000E14C
		public static ulong readQword(int address)
		{
			byte[] array = new byte[8];
			imports.ReadProcessMemory(EyeStep.handle, address, array, 8, ref util.nothing);
			return BitConverter.ToUInt64(array, 0);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x0000FF7C File Offset: 0x0000E17C
		public static void placeJmp(int from, int to)
		{
			int i;
			for (i = 0; i < 5; i += EyeStep.read(from + i).len)
			{
			}
			uint protect = util.setPageProtect(from, 64U, 1023);
			util.writeByte(from, 233);
			util.writeInt(from + 1, to - from - 5);
			for (int j = 5; j < i; j++)
			{
				util.writeByte(from + j, 144);
			}
			util.setPageProtect(from, protect, 1023);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x0000FFF0 File Offset: 0x0000E1F0
		public static void placeCall(int from, int to)
		{
			int i;
			for (i = 0; i < 5; i += EyeStep.read(from + i).len)
			{
			}
			uint protect = util.setPageProtect(from, 64U, 1023);
			util.writeByte(from, 232);
			util.writeInt(from + 1, to - from - 5);
			for (int j = 5; j < i; j++)
			{
				util.writeByte(from + j, 144);
			}
			util.setPageProtect(from, protect, 1023);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00010061 File Offset: 0x0000E261
		public static void placeTrampoline(int from, int to, int length)
		{
			util.placeJmp(from, to);
			util.placeJmp(to + length, from + 5);
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00010075 File Offset: 0x0000E275
		public static int rebase(int address)
		{
			return EyeStep.base_module + address;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x0001007E File Offset: 0x0000E27E
		public static int aslr(int address)
		{
			return EyeStep.base_module + address - 4194304;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x0001008D File Offset: 0x0000E28D
		public static int raslr(int address)
		{
			return address - EyeStep.base_module + 4194304;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x0001009C File Offset: 0x0000E29C
		public static int getRel(int address)
		{
			return address + 5 + util.readInt(address + 1);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x000100AA File Offset: 0x0000E2AA
		public static bool isRel(int address)
		{
			return util.getRel(address) % 16 == 0;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000100B8 File Offset: 0x0000E2B8
		public static bool isCall(int address)
		{
			return util.isRel(address) && util.getRel(address) > EyeStep.base_module && util.getRel(address) < EyeStep.base_module + EyeStep.base_module_size;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000100E4 File Offset: 0x0000E2E4
		public static bool isPrologue(int address)
		{
			return address % 16 == 0 && ((util.readByte(address) == 85 && util.readUShort(address + 1) == 60555) || (util.readByte(address) == 83 && util.readUShort(address + 1) == 56459) || (util.readByte(address) == 86 && util.readUShort(address + 1) == 62603));
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00010148 File Offset: 0x0000E348
		public static bool isEpilogue(int address)
		{
			return util.readUShort(address - 1) == 50013 || (util.readUShort(address - 1) == 49757 && util.readUShort(address + 1) >= 0 && util.readUShort(address + 1) % 4 == 0) || util.readUShort(address - 1) == 50121 || (util.readUShort(address - 1) == 49865 && util.readUShort(address + 1) >= 0 && util.readUShort(address + 1) % 4 == 0);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000101C6 File Offset: 0x0000E3C6
		public static bool isValidCode(int address)
		{
			return util.readDouble(address) != 0.0 || util.readDouble(address + 8) != 0.0;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000101F4 File Offset: 0x0000E3F4
		public static int nextPrologue(int address)
		{
			int num;
			if (util.isPrologue(address))
			{
				num = address + 16;
			}
			else
			{
				num = address + address % 16;
			}
			while (!util.isPrologue(num) || !util.isValidCode(num))
			{
				num += 16;
			}
			return num;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00010234 File Offset: 0x0000E434
		public static int prevPrologue(int address)
		{
			int num;
			if (util.isPrologue(address))
			{
				num = address - 16;
			}
			else
			{
				num = address - address % 16;
			}
			while (!util.isPrologue(num) || !util.isValidCode(num))
			{
				num -= 16;
			}
			return num;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00010271 File Offset: 0x0000E471
		public static int getPrologue(int address)
		{
			if (!util.isPrologue(address))
			{
				return util.prevPrologue(address);
			}
			return address;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00010284 File Offset: 0x0000E484
		public static int getEpilogue(int address)
		{
			int num = util.nextPrologue(address);
			int num2 = num;
			while (!util.isEpilogue(num2))
			{
				num2--;
			}
			if (num2 < address)
			{
				num2 = num;
				if (util.readByte(num2 - 1) == 204)
				{
					return num2 - 1;
				}
			}
			return num2;
		}

		// Token: 0x06000052 RID: 82 RVA: 0x000102C4 File Offset: 0x0000E4C4
		public static short getRetn(int address)
		{
			int epilogue = util.getEpilogue(address);
			if (util.readByte(epilogue) == 194)
			{
				return util.readShort(epilogue + 1);
			}
			return 0;
		}

		// Token: 0x06000053 RID: 83 RVA: 0x000102F0 File Offset: 0x0000E4F0
		public static int nextCall(int address, bool location = false, bool func_requires_prologue = false)
		{
			int num = address;
			if (util.readByte(num) == 232 || util.readByte(num) == 233)
			{
				num++;
			}
			while (util.isValidCode(num))
			{
				if ((util.readByte(num) == 232 || util.readByte(num) == 233) && util.isCall(num))
				{
					bool flag = true;
					if (func_requires_prologue && !util.isPrologue(util.getRel(num)))
					{
						flag = false;
					}
					if (flag)
					{
						break;
					}
				}
				num++;
			}
			if (location)
			{
				return num;
			}
			return util.getRel(num);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00010370 File Offset: 0x0000E570
		public static int prevCall(int address, bool location = false, bool func_requires_prologue = false)
		{
			int num = address;
			if (util.readByte(num) == 232 || util.readByte(num) == 233)
			{
				num--;
			}
			while (util.isValidCode(num))
			{
				if ((util.readByte(num) == 232 || util.readByte(num) == 233) && util.isCall(num))
				{
					bool flag = true;
					if (func_requires_prologue && !util.isPrologue(util.getRel(num)))
					{
						flag = false;
					}
					if (flag)
					{
						break;
					}
				}
				num--;
			}
			if (location)
			{
				return num;
			}
			return util.getRel(num);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x000103F0 File Offset: 0x0000E5F0
		public static int nextRef(int start, int func_search, bool prologue = true)
		{
			int num = start;
			while ((util.readByte(num) != 232 && util.readByte(num) != 233) || util.getRel(num) != func_search)
			{
				num++;
			}
			if (!prologue)
			{
				return num;
			}
			return util.getPrologue(num);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00010434 File Offset: 0x0000E634
		public static int prevRef(int start, int func_search, bool prologue = true)
		{
			int num = start;
			while ((util.readByte(num) != 232 && util.readByte(num) != 233) || util.getRel(num) != func_search)
			{
				num--;
			}
			if (!prologue)
			{
				return num;
			}
			return util.getPrologue(num);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00010478 File Offset: 0x0000E678
		public static int nextPointer(int start, int ptr_search, bool prologue)
		{
			int num = start + 4;
			while (util.readInt(num) != ptr_search)
			{
				num++;
			}
			if (!prologue)
			{
				return num;
			}
			return util.getPrologue(num);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000104A4 File Offset: 0x0000E6A4
		public static int prevPointer(int start, int ptr_search, bool prologue)
		{
			int num = start;
			while (util.readInt(num) != ptr_search)
			{
				num--;
			}
			if (!prologue)
			{
				return num;
			}
			return util.getPrologue(num);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000104D0 File Offset: 0x0000E6D0
		public static List<int> getCalls(int address)
		{
			List<int> list = new List<int>();
			int i = address;
			int num = util.nextPrologue(i);
			while (i < num)
			{
				list.Add(util.nextCall(i, false, false));
				i = util.nextCall(i, true, false) + 5;
			}
			return list;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0001050C File Offset: 0x0000E70C
		public static List<int> getPointers(int address)
		{
			List<int> list = new List<int>();
			int i = address;
			int num = util.nextPrologue(i);
			while (i < num)
			{
				EyeStep.inst inst = EyeStep.read(i);
				if ((inst.source().flags & 512U) == 512U && inst.source().disp32 % 4U == 0U)
				{
					list.Add((int)inst.source().disp32);
				}
				else if ((inst.destination().flags & 512U) == 512U && inst.destination().disp32 % 4U == 0U)
				{
					list.Add((int)inst.destination().disp32);
				}
				i += inst.len;
			}
			return list;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x000105B8 File Offset: 0x0000E7B8
		public static byte getConvention(int func, int n_expected_args)
		{
			byte result = 0;
			if (n_expected_args == 0)
			{
				return result;
			}
			int num = func + 16;
			while (!util.isPrologue(num) && util.isValidCode(num))
			{
				num += 16;
			}
			int num2 = 0;
			while (!util.isEpilogue(num))
			{
				num--;
			}
			if (util.readByte(num) == 194)
			{
				result = 1;
			}
			else
			{
				result = 0;
			}
			EyeStep.inst inst;
			for (int i = func; i < num; i += inst.len)
			{
				inst = EyeStep.read(i);
				if ((inst.flags & 2U) == 2U || (inst.flags & 1U) == 1U)
				{
					EyeStep.operand operand = inst.source();
					EyeStep.operand operand2 = inst.destination();
					if ((operand.flags & 4096U) == 4096U || (operand.flags & 16384U) == 16384U)
					{
						if ((operand2.flags & 4096U) == 4096U || (operand2.flags & 16384U) == 16384U)
						{
							if ((operand2.flags & 16U) == 16U && operand2.reg[0] == 5 && operand2.imm8 != 4 && operand2.imm8 < 127 && (int)operand2.imm8 > num2)
							{
								num2 = (int)operand2.imm8;
							}
						}
						else if ((operand.flags & 16U) == 16U && operand.reg[0] == 5 && operand.imm8 != 4 && operand.imm8 < 127 && (int)operand.imm8 > num2)
						{
							num2 = (int)operand.imm8;
						}
					}
				}
			}
			if (num2 == 0)
			{
				if (n_expected_args == 1)
				{
					return 3;
				}
				if (n_expected_args == 2)
				{
					return 2;
				}
			}
			num2 -= 8;
			num2 = num2 / 4 + 1;
			if (num2 == n_expected_args - 1)
			{
				result = 3;
			}
			else if (num2 == n_expected_args - 2)
			{
				result = 2;
			}
			return result;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x0001076C File Offset: 0x0000E96C
		public static byte getConvention(int func)
		{
			util.function_info function_info = new util.function_info();
			function_info.analyze(func);
			return function_info.convention;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00010780 File Offset: 0x0000E980
		public static int createRoutine(int function, byte n_args)
		{
			byte convention = util.getConvention(function, (int)n_args);
			bool flag = false;
			int num = 0;
			byte[] array = new byte[128];
			int num2 = imports.VirtualAllocEx(EyeStep.handle, 0, 128, 12288U, 64U);
			if (num2 == 0)
			{
				throw new Exception("Error while allocating memory");
			}
			array[num++] = 85;
			array[num++] = 139;
			array[num++] = 236;
			if (convention == 0)
			{
				for (int i = (int)(n_args * 4 + 8); i > 8; i -= 4)
				{
					array[num++] = byte.MaxValue;
					array[num++] = 117;
					array[num++] = (byte)(i - 4);
				}
				array[num++] = 232;
				byte[] bytes = BitConverter.GetBytes(function - (num2 + num + 4));
				array[num++] = bytes[0];
				array[num++] = bytes[1];
				array[num++] = bytes[2];
				array[num++] = bytes[3];
				array[num++] = 131;
				array[num++] = 196;
				array[num++] = n_args * 4;
			}
			else if (convention == 1)
			{
				for (int j = (int)(n_args * 4 + 8); j > 8; j -= 4)
				{
					array[num++] = byte.MaxValue;
					array[num++] = 117;
					array[num++] = (byte)(j - 4);
				}
				array[num++] = 232;
				byte[] bytes2 = BitConverter.GetBytes(function - (num2 + num + 4));
				array[num++] = bytes2[0];
				array[num++] = bytes2[1];
				array[num++] = bytes2[2];
				array[num++] = bytes2[3];
			}
			else if (convention == 3)
			{
				array[num++] = 81;
				for (int k = (int)n_args; k > 1; k--)
				{
					array[num++] = byte.MaxValue;
					array[num++] = 117;
					array[num++] = (byte)((k + 1) * 4);
				}
				array[num++] = 139;
				array[num++] = 77;
				array[num++] = 8;
				array[num++] = 232;
				byte[] bytes3 = BitConverter.GetBytes(function - (num2 + num + 4));
				array[num++] = bytes3[0];
				array[num++] = bytes3[1];
				array[num++] = bytes3[2];
				array[num++] = bytes3[3];
				array[num++] = 89;
			}
			else if (convention == 2)
			{
				array[num++] = 81;
				array[num++] = 82;
				for (int l = (int)n_args; l > 2; l--)
				{
					array[num++] = byte.MaxValue;
					array[num++] = 117;
					array[num++] = (byte)((l + 1) * 4);
				}
				array[num++] = 139;
				array[num++] = 77;
				array[num++] = 8;
				array[num++] = 139;
				array[num++] = 85;
				array[num++] = 12;
				array[num++] = 232;
				byte[] bytes4 = BitConverter.GetBytes(function - (num2 + num + 4));
				array[num++] = bytes4[0];
				array[num++] = bytes4[1];
				array[num++] = bytes4[2];
				array[num++] = bytes4[3];
				array[num++] = 89;
				array[num++] = 90;
			}
			if (!flag)
			{
				array[num++] = 93;
				array[num++] = 195;
			}
			else
			{
				array[num++] = 194;
				array[num++] = n_args * 4;
				array[num++] = 0;
			}
			util.writeBytes(num2, array, num);
			util.savedRoutines.Add(num2);
			return num2;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00010B42 File Offset: 0x0000ED42
		public static string getAnalysis(int func)
		{
			util.function_info function_info = new util.function_info();
			function_info.analyze(func);
			return function_info.psuedocode;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00010B58 File Offset: 0x0000ED58
		public static void disableFunction(int func)
		{
			uint protect = util.setPageProtect(func, 64U, 1023);
			if (util.isPrologue(func))
			{
				short retn = util.getRetn(func);
				if (retn != 0)
				{
					util.writeByte(func + 3, 194);
					util.writeShort(func + 4, retn);
				}
				else
				{
					util.writeByte(func + 3, 195);
				}
			}
			else
			{
				util.writeByte(func, 195);
			}
			util.setPageProtect(func, protect, 1023);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00010BC4 File Offset: 0x0000EDC4
		public static List<int> debug_r32(int address, byte r32, int offset, int count)
		{
			List<int> list = new List<int>();
			int i;
			for (i = 0; i < 5; i += EyeStep.read(address + i).len)
			{
			}
			byte[] array = util.readBytes(address, i);
			int num = imports.VirtualAllocEx(EyeStep.handle, 0, 256, 4096U, 64U);
			int num2 = num + 128;
			int num3 = num + 124;
			byte[] array2 = new byte[128];
			int num4 = 0;
			for (int j = 0; j < i; j++)
			{
				array2[num4++] = array[j];
			}
			array2[num4++] = 96;
			array2[num4++] = 80;
			byte[] bytes;
			for (int k = 0; k < count; k++)
			{
				array2[num4++] = 139;
				if (offset + count * 4 < 128)
				{
					array2[num4++] = 64 + r32;
					array2[num4++] = (byte)(offset + k * 4);
				}
				else
				{
					array2[num4++] = 128 + r32;
					bytes = BitConverter.GetBytes(offset + k * 4);
					array2[num4++] = bytes[0];
					array2[num4++] = bytes[1];
					array2[num4++] = bytes[2];
					array2[num4++] = bytes[3];
				}
				array2[num4++] = 163;
				bytes = BitConverter.GetBytes(num2 + k * 4);
				array2[num4++] = bytes[0];
				array2[num4++] = bytes[1];
				array2[num4++] = bytes[2];
				array2[num4++] = bytes[3];
			}
			array2[num4++] = 199;
			array2[num4++] = 5;
			bytes = BitConverter.GetBytes(num3);
			array2[num4++] = bytes[0];
			array2[num4++] = bytes[1];
			array2[num4++] = bytes[2];
			array2[num4++] = bytes[3];
			array2[num4++] = 1;
			array2[num4++] = 0;
			array2[num4++] = 0;
			array2[num4++] = 0;
			array2[num4++] = 88;
			array2[num4++] = 97;
			util.writeBytes(num, array2, num4);
			util.placeTrampoline(address, num, num4);
			while (util.readInt(num3) == 0)
			{
				Thread.Sleep(10);
			}
			for (int l = 0; l < count; l++)
			{
				list.Add(util.readInt(num2 + l * 4));
			}
			uint protect = util.setPageProtect(address, 64U, 1023);
			util.writeBytes(address, array, i);
			util.setPageProtect(address, protect, 1023);
			imports.VirtualFreeEx(EyeStep.handle, num, 0, 32768U);
			return list;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00010E85 File Offset: 0x0000F085
		public static int inject_function(int address, string code)
		{
			if (address == 0)
			{
				return imports.VirtualAllocEx(EyeStep.handle, 0, 1024, 12288U, 64U);
			}
			return address;
		}

		// Token: 0x040000CA RID: 202
		public const byte c_cdecl = 0;

		// Token: 0x040000CB RID: 203
		public const byte c_stdcall = 1;

		// Token: 0x040000CC RID: 204
		public const byte c_fastcall = 2;

		// Token: 0x040000CD RID: 205
		public const byte c_thiscall = 3;

		// Token: 0x040000CE RID: 206
		public const byte c_auto = 4;

		// Token: 0x040000CF RID: 207
		public static List<int> savedRoutines = new List<int>();

		// Token: 0x040000D0 RID: 208
		public static int nothing = 0;

		// Token: 0x040000D1 RID: 209
		public static string[] convs = new string[]
		{
			"__cdecl",
			"__stdcall",
			"__fastcall",
			"__thiscall",
			"[auto-generated]"
		};

		// Token: 0x02000013 RID: 19
		public class function_arg
		{
			// Token: 0x06000076 RID: 118 RVA: 0x00011923 File Offset: 0x0000FB23
			public function_arg(int _ebp_offset, int _bits, bool _isCharPointer, int _location)
			{
				this.ebp_offset = _ebp_offset;
				this.bits = _bits;
				this.isCharPointer = _isCharPointer;
				this.location = _location;
			}

			// Token: 0x04000127 RID: 295
			public int ebp_offset;

			// Token: 0x04000128 RID: 296
			public int bits;

			// Token: 0x04000129 RID: 297
			public bool isCharPointer;

			// Token: 0x0400012A RID: 298
			public int location;
		}

		// Token: 0x02000014 RID: 20
		public class function_info
		{
			// Token: 0x06000077 RID: 119 RVA: 0x00011948 File Offset: 0x0000FB48
			public function_info()
			{
				this.args = new List<util.function_arg>();
				this.start_address = 0;
				this.function_size = 0;
				this.convention = 4;
				this.return_bits = 0;
				this.stack_cleanup = 0;
				this.psuedocode = "";
			}

			// Token: 0x06000078 RID: 120 RVA: 0x00011994 File Offset: 0x0000FB94
			public void analyze(int func)
			{
				int num = util.getEpilogue(func);
				if (util.readByte(num) == 195)
				{
					this.stack_cleanup = 0;
					num++;
				}
				else if (util.readByte(num) == 194)
				{
					this.stack_cleanup = util.readShort(num + 1);
					num += 3;
				}
				this.start_address = func;
				this.function_size = num - func;
				List<int> list = new List<int>();
				for (int i = 0; i < this.function_size; i++)
				{
					byte[] array = util.readBytes(this.start_address + i, 8);
					if (array[0] == 138 && array[2] >= 64 && array[2] < 72 && array[3] == 132 && array[4] == 192 && array[5] == 117)
					{
						list.Add(this.start_address + i);
						i += 8;
					}
				}
				bool flag = false;
				bool flag2 = false;
				int j = func;
				EyeStep.operand operand = new EyeStep.operand();
				List<int> list2 = new List<int>();
				while (j < num)
				{
					EyeStep.inst inst = EyeStep.read(j);
					EyeStep.operand operand2 = inst.source();
					EyeStep.operand operand3 = inst.destination();
					string text = "";
					text += inst.data;
					if (this.convention == 4)
					{
						if (text.Contains("retn"))
						{
							this.stack_cleanup = 0;
							this.convention = 0;
						}
						else if (text.Contains("ret "))
						{
							this.stack_cleanup = util.readShort(inst.address + 1);
							this.convention = 1;
						}
					}
					if (operand2.reg.Count > 0)
					{
						if ((operand2.flags & 4096U) == 4096U && operand2.reg[0] == 5 && operand2.imm8 >= 8 && operand2.imm8 < 64)
						{
							bool flag3 = false;
							foreach (int num2 in list2)
							{
								if ((int)operand2.imm8 == num2)
								{
									flag3 = true;
								}
							}
							if (!flag3)
							{
								list2.Add((int)operand2.imm8);
								this.args.Add(new util.function_arg((int)operand2.imm8, 32, false, j));
							}
						}
						if (operand2.reg[0] == 0)
						{
							if (text.Contains("mov ") || text.Contains("or "))
							{
								operand = operand3;
							}
						}
						else if (operand2.reg[0] == 1)
						{
							flag = true;
						}
						else if (operand2.reg[0] == 2)
						{
							this.convention = 4;
							flag2 = true;
							break;
						}
						if (operand3.reg.Count > 0)
						{
							if ((operand3.flags & 4096U) == 4096U && operand3.reg[0] == 5 && operand3.imm8 >= 8 && operand3.imm8 < 64)
							{
								bool flag4 = false;
								foreach (int num3 in list2)
								{
									if ((int)operand3.imm8 == num3)
									{
										flag4 = true;
									}
								}
								if (!flag4)
								{
									list2.Add((int)operand3.imm8);
									this.args.Add(new util.function_arg((int)operand3.imm8, 32, false, j));
								}
							}
							if ((operand2.reg[0] != 2 || operand3.reg[0] != 2) && (operand2.reg[0] != 1 || operand3.reg[0] != 1))
							{
								if (operand3.reg[0] == 2 && !flag2)
								{
									this.convention = 2;
									break;
								}
								if (operand3.reg[0] == 1 && !flag && this.convention != 2)
								{
									this.convention = 3;
								}
							}
						}
						else if (text.Contains("pop "))
						{
							if (operand2.reg[0] == 1)
							{
								flag = false;
							}
							else if (operand2.reg[0] == 2)
							{
								flag2 = false;
							}
						}
						else if (text.Contains("push "))
						{
							if (operand2.reg[0] == 1)
							{
								flag = true;
							}
							else if (operand2.reg[0] == 2)
							{
								flag2 = true;
							}
						}
					}
					j += inst.len;
				}
				if (this.convention == 3)
				{
					this.args.Add(new util.function_arg(0, 32, false, 0));
				}
				else if (this.convention == 2)
				{
					this.args.Add(new util.function_arg(0, 32, false, 0));
					this.args.Add(new util.function_arg(0, 32, false, 0));
				}
				else if (this.convention == 4)
				{
					if (this.stack_cleanup == 0)
					{
						this.convention = 0;
					}
					else
					{
						this.convention = 1;
					}
				}
				if (list.Count > 0)
				{
					foreach (int num4 in list)
					{
						for (int k = this.args.Count - 1; k >= 0; k--)
						{
							if (this.args[k].location < num4)
							{
								this.args[k].isCharPointer = true;
								break;
							}
						}
					}
				}
				if ((operand.flags & 128U) == 128U || (operand.flags & 1024U) == 1024U)
				{
					this.psuedocode += "bool ";
					this.return_bits = 1;
				}
				else if ((operand.flags & 256U) == 256U || (operand.flags & 2048U) == 2048U)
				{
					this.psuedocode += "short ";
					this.return_bits = 2;
				}
				else if ((operand.flags & 512U) == 512U || (operand.flags & 4096U) == 4096U)
				{
					this.psuedocode += "int ";
					this.return_bits = 4;
				}
				else
				{
					this.psuedocode += "int ";
					this.return_bits = 4;
				}
				this.psuedocode += util.convs[(int)this.convention];
				this.psuedocode += " ";
				this.psuedocode += this.start_address.ToString("X8");
				this.psuedocode += "(";
				for (int l = 0; l < this.args.Count; l++)
				{
					if (this.args[l].isCharPointer)
					{
						this.psuedocode += "const char*";
					}
					else if (this.args[l].bits == 8)
					{
						this.psuedocode += "byte";
					}
					else if (this.args[l].bits == 16)
					{
						this.psuedocode += "short";
					}
					else if (this.args[l].bits == 32)
					{
						this.psuedocode += "int";
					}
					this.psuedocode += " a";
					this.psuedocode += Convert.ToString(l + 1);
					if (l < this.args.Count - 1)
					{
						this.psuedocode += ", ";
					}
				}
				this.psuedocode += ")";
			}

			// Token: 0x0400012B RID: 299
			public int start_address;

			// Token: 0x0400012C RID: 300
			public int function_size;

			// Token: 0x0400012D RID: 301
			public byte convention;

			// Token: 0x0400012E RID: 302
			public byte return_bits;

			// Token: 0x0400012F RID: 303
			public short stack_cleanup;

			// Token: 0x04000130 RID: 304
			public List<util.function_arg> args;

			// Token: 0x04000131 RID: 305
			public string psuedocode;
		}
	}
}
