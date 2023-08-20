using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EyeStepPackage
{
	// Token: 0x02000007 RID: 7
	public class EmRemote
	{
		// Token: 0x06000028 RID: 40 RVA: 0x0000EC6C File Offset: 0x0000CE6C
		public EmRemote()
		{
			this.routines = new Dictionary<string, EmRemote.RoutineInfo>();
			this.remote_loc = 0;
			this.func_id_loc = 0;
			this.ret_loc_small = 0;
			this.ret_loc_large = 0;
			this.args_loc = 0;
			this.funcs_loc = 0;
			this.spoofroutine = 0;
			this.spoofredirect = 0;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x0000ECC4 File Offset: 0x0000CEC4
		~EmRemote()
		{
			this.Flush();
		}

		// Token: 0x0600002A RID: 42 RVA: 0x0000ECF0 File Offset: 0x0000CEF0
		public void Flush()
		{
			util.placeJmp(this.remote_loc + 6, this.remote_loc + 25);
			Thread.Sleep(1000);
			foreach (KeyValuePair<string, EmRemote.RoutineInfo> keyValuePair in this.routines)
			{
				imports.VirtualFreeEx(EyeStep.handle, keyValuePair.Value.routine, 0, 32768U);
			}
			imports.VirtualFreeEx(EyeStep.handle, this.remote_loc, 0, 32768U);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x0000ED90 File Offset: 0x0000CF90
		public void Load()
		{
			this.remote_loc = imports.VirtualAllocEx(EyeStep.handle, 0, 2047, 12288U, 64U);
			this.func_id_loc = this.remote_loc + 512;
			this.ret_loc_small = this.remote_loc + 516;
			this.ret_loc_large = this.remote_loc + 520;
			this.args_loc = this.remote_loc + 528;
			this.funcs_loc = this.remote_loc + 680;
			byte[] array = new byte[256];
			int count = 0;
			array[count++] = 85;
			array[count++] = 139;
			array[count++] = 236;
			array[count++] = 80;
			array[count++] = 86;
			array[count++] = 87;
			array[count++] = 139;
			array[count++] = 61;
			byte[] bytes = BitConverter.GetBytes(this.func_id_loc);
			array[count++] = bytes[0];
			array[count++] = bytes[1];
			array[count++] = bytes[2];
			array[count++] = bytes[3];
			array[count++] = 129;
			array[count++] = byte.MaxValue;
			array[count++] = 0;
			array[count++] = 0;
			array[count++] = 0;
			array[count++] = 0;
			array[count++] = 116;
			array[count++] = 242;
			array[count++] = byte.MaxValue;
			array[count++] = 37;
			bytes = BitConverter.GetBytes(this.func_id_loc);
			array[count++] = bytes[0];
			array[count++] = bytes[1];
			array[count++] = bytes[2];
			array[count++] = bytes[3];
			array[count++] = 88;
			array[count++] = 94;
			array[count++] = 95;
			array[count++] = 93;
			array[count++] = 194;
			array[count++] = 4;
			array[count++] = 0;
			util.writeBytes(this.remote_loc, array, count);
			int num = 0;
			imports.CreateRemoteThread(EyeStep.handle, 0, 0U, this.remote_loc, 0, 0U, out num);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x0000EFA4 File Offset: 0x0000D1A4
		public void Add(string routine_name, int func, params string[] arg_types)
		{
			byte convention = util.getConvention(func, arg_types.Length);
			int num = imports.VirtualAllocEx(EyeStep.handle, 0, 256, 12288U, 64U);
			this.routines[routine_name] = new EmRemote.RoutineInfo(num, convention);
			byte[] array = new byte[256];
			int num2 = 0;
			int i = 0;
			byte[] bytes;
			if (convention == 3 || convention == 2)
			{
				array[num2++] = 139;
				array[num2++] = 13;
				bytes = BitConverter.GetBytes(this.args_loc + 8 * i++);
				array[num2++] = bytes[0];
				array[num2++] = bytes[1];
				array[num2++] = bytes[2];
				array[num2++] = bytes[3];
				if (convention == 2)
				{
					array[num2++] = 139;
					array[num2++] = 21;
					bytes = BitConverter.GetBytes(this.args_loc + 8 * i++);
					array[num2++] = bytes[0];
					array[num2++] = bytes[1];
					array[num2++] = bytes[2];
					array[num2++] = bytes[3];
				}
			}
			int num3 = arg_types.Length - 1;
			while (i < arg_types.Length)
			{
				if (arg_types[num3] == "double")
				{
					array[num2++] = 15;
					array[num2++] = 16;
					array[num2++] = 5;
					bytes = BitConverter.GetBytes(this.args_loc + 8 * i++);
					array[num2++] = bytes[0];
					array[num2++] = bytes[1];
					array[num2++] = bytes[2];
					array[num2++] = bytes[3];
					array[num2++] = 242;
					array[num2++] = 15;
					array[num2++] = 17;
					array[num2++] = 4;
					array[num2++] = 36;
				}
				else
				{
					array[num2++] = byte.MaxValue;
					array[num2++] = 53;
					bytes = BitConverter.GetBytes(this.args_loc + 8 * i++);
					array[num2++] = bytes[0];
					array[num2++] = bytes[1];
					array[num2++] = bytes[2];
					array[num2++] = bytes[3];
				}
				num3--;
			}
			array[num2++] = 191;
			bytes = BitConverter.GetBytes(func);
			array[num2++] = bytes[0];
			array[num2++] = bytes[1];
			array[num2++] = bytes[2];
			array[num2++] = bytes[3];
			array[num2++] = byte.MaxValue;
			array[num2++] = 215;
			array[num2++] = 163;
			bytes = BitConverter.GetBytes(this.ret_loc_small);
			array[num2++] = bytes[0];
			array[num2++] = bytes[1];
			array[num2++] = bytes[2];
			array[num2++] = bytes[3];
			array[num2++] = 243;
			array[num2++] = 15;
			array[num2++] = 126;
			array[num2++] = 4;
			array[num2++] = 36;
			array[num2++] = 102;
			array[num2++] = 15;
			array[num2++] = 214;
			array[num2++] = 5;
			bytes = BitConverter.GetBytes(this.ret_loc_large);
			array[num2++] = bytes[0];
			array[num2++] = bytes[1];
			array[num2++] = bytes[2];
			array[num2++] = bytes[3];
			if (convention == 0)
			{
				array[num2++] = 129;
				array[num2++] = 196;
				bytes = BitConverter.GetBytes(arg_types.Length * 4);
				array[num2++] = bytes[0];
				array[num2++] = bytes[1];
				array[num2++] = bytes[2];
				array[num2++] = bytes[3];
			}
			array[num2++] = 199;
			array[num2++] = 5;
			bytes = BitConverter.GetBytes(this.func_id_loc);
			array[num2++] = bytes[0];
			array[num2++] = bytes[1];
			array[num2++] = bytes[2];
			array[num2++] = bytes[3];
			array[num2++] = 0;
			array[num2++] = 0;
			array[num2++] = 0;
			array[num2++] = 0;
			util.writeBytes(num, array, num2);
			util.placeJmp(num + num2, this.remote_loc + 6);
			util.writeInt(this.funcs_loc + this.routines.Count * 4, num);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x0000F3E8 File Offset: 0x0000D5E8
		public void AddProtected(string routine_name, int func, params string[] arg_types)
		{
			if (this.spoofredirect == 0 || this.spoofroutine == 0)
			{
				this.spoofroutine = scanner.scan("FF25????????55", true, 1, 0, null)[0];
				this.spoofredirect = util.readInt(this.spoofroutine + 2);
			}
			byte convention = util.getConvention(func, arg_types.Length);
			int num = imports.VirtualAllocEx(EyeStep.handle, 0, 256, 12288U, 64U);
			if (util.isPrologue(func))
			{
				func += 3;
			}
			this.routines[routine_name] = new EmRemote.RoutineInfo(num, convention);
			byte[] array = new byte[256];
			int num2 = 0;
			int i = 0;
			byte[] bytes;
			if (convention == 3 || convention == 2)
			{
				array[num2++] = 139;
				array[num2++] = 13;
				bytes = BitConverter.GetBytes(this.args_loc + 8 * i++);
				array[num2++] = bytes[0];
				array[num2++] = bytes[1];
				array[num2++] = bytes[2];
				array[num2++] = bytes[3];
				if (convention == 2)
				{
					array[num2++] = 139;
					array[num2++] = 21;
					bytes = BitConverter.GetBytes(this.args_loc + 8 * i++);
					array[num2++] = bytes[0];
					array[num2++] = bytes[1];
					array[num2++] = bytes[2];
					array[num2++] = bytes[3];
				}
			}
			int num3 = arg_types.Length - 1;
			while (i < arg_types.Length)
			{
				if (arg_types[num3] == "double")
				{
					array[num2++] = 15;
					array[num2++] = 16;
					array[num2++] = 5;
					bytes = BitConverter.GetBytes(this.args_loc + 8 * i++);
					array[num2++] = bytes[0];
					array[num2++] = bytes[1];
					array[num2++] = bytes[2];
					array[num2++] = bytes[3];
					array[num2++] = 242;
					array[num2++] = 15;
					array[num2++] = 17;
					array[num2++] = 4;
					array[num2++] = 36;
				}
				else
				{
					array[num2++] = byte.MaxValue;
					array[num2++] = 53;
					bytes = BitConverter.GetBytes(this.args_loc + 8 * i++);
					array[num2++] = bytes[0];
					array[num2++] = bytes[1];
					array[num2++] = bytes[2];
					array[num2++] = bytes[3];
				}
				num3--;
			}
			array[num2++] = 232;
			array[num2++] = 0;
			array[num2++] = 0;
			array[num2++] = 0;
			array[num2++] = 0;
			int num4 = (int)(util.readByte(func - 3) % 8);
			for (int j = 0; j < 3; j++)
			{
				array[num2++] = util.readByte(func - 3 + j);
			}
			array[num2++] = 139;
			array[num2++] = (byte)(120 + num4);
			array[num2++] = 4;
			array[num2++] = 129;
			array[num2++] = 199;
			array[num2++] = 33;
			array[num2++] = 0;
			array[num2++] = 0;
			array[num2++] = 0;
			array[num2++] = 137;
			array[num2++] = 61;
			bytes = BitConverter.GetBytes(this.spoofredirect);
			array[num2++] = bytes[0];
			array[num2++] = bytes[1];
			array[num2++] = bytes[2];
			array[num2++] = bytes[3];
			array[num2++] = 191;
			bytes = BitConverter.GetBytes(this.spoofroutine);
			array[num2++] = bytes[0];
			array[num2++] = bytes[1];
			array[num2++] = bytes[2];
			array[num2++] = bytes[3];
			array[num2++] = 137;
			array[num2++] = (byte)(120 + num4);
			array[num2++] = 4;
			array[num2++] = 191;
			bytes = BitConverter.GetBytes(func);
			array[num2++] = bytes[0];
			array[num2++] = bytes[1];
			array[num2++] = bytes[2];
			array[num2++] = bytes[3];
			array[num2++] = byte.MaxValue;
			array[num2++] = 231;
			array[num2++] = 163;
			bytes = BitConverter.GetBytes(this.ret_loc_small);
			array[num2++] = bytes[0];
			array[num2++] = bytes[1];
			array[num2++] = bytes[2];
			array[num2++] = bytes[3];
			array[num2++] = 243;
			array[num2++] = 15;
			array[num2++] = 126;
			array[num2++] = 4;
			array[num2++] = 36;
			array[num2++] = 102;
			array[num2++] = 15;
			array[num2++] = 214;
			array[num2++] = 5;
			bytes = BitConverter.GetBytes(this.ret_loc_large);
			array[num2++] = bytes[0];
			array[num2++] = bytes[1];
			array[num2++] = bytes[2];
			array[num2++] = bytes[3];
			if (convention == 0)
			{
				array[num2++] = 129;
				array[num2++] = 196;
				bytes = BitConverter.GetBytes(arg_types.Length * 4);
				array[num2++] = bytes[0];
				array[num2++] = bytes[1];
				array[num2++] = bytes[2];
				array[num2++] = bytes[3];
			}
			array[num2++] = 199;
			array[num2++] = 5;
			bytes = BitConverter.GetBytes(this.func_id_loc);
			array[num2++] = bytes[0];
			array[num2++] = bytes[1];
			array[num2++] = bytes[2];
			array[num2++] = bytes[3];
			array[num2++] = 0;
			array[num2++] = 0;
			array[num2++] = 0;
			array[num2++] = 0;
			util.writeBytes(num, array, num2);
			util.placeJmp(num + num2, this.remote_loc + 6);
			util.writeInt(this.funcs_loc + this.routines.Count * 4, num);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x0000F9E0 File Offset: 0x0000DBE0
		public Tuple<uint, ulong> Call(string routine_name, params object[] args)
		{
			EmRemote.RoutineInfo routineInfo = this.routines[routine_name];
			int routine = routineInfo.routine;
			byte conv = routineInfo.conv;
			List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>();
			for (int i = 0; i < args.Length; i++)
			{
				object obj;
				if (conv == 3 && i == 0)
				{
					obj = args[i];
				}
				else if (conv == 3 && i < 2)
				{
					obj = args[i];
				}
				else
				{
					obj = args[args.Length - 1 - i];
				}
				FunctionArg functionArg;
				if (obj is string)
				{
					functionArg = new FunctionArg((string)obj);
				}
				else if (obj is ulong || obj is double || obj is decimal)
				{
					functionArg = new FunctionArg((double)obj);
				}
				else
				{
					functionArg = new FunctionArg((int)obj);
				}
				if (functionArg.type == "string")
				{
					int length = functionArg.str.Length;
					functionArg.small = this.remote_loc + 1024 + 256 * list.Count;
					util.writeBytes(functionArg.small, Encoding.ASCII.GetBytes(functionArg.str), -1);
					util.writeInt(functionArg.small + length + 4 + length % 4, length);
					list.Add(new KeyValuePair<int, int>(functionArg.small, length));
					util.writeInt(this.args_loc + i * 8, functionArg.small);
				}
				else if (functionArg.type == "smallvalue")
				{
					util.writeInt(this.args_loc + i * 8, functionArg.small);
				}
				else if (functionArg.type == "largevalue")
				{
					util.writeDouble(this.args_loc + i * 8, functionArg.large);
				}
			}
			util.writeInt(this.func_id_loc, routine);
			while (util.readInt(this.func_id_loc) != 0)
			{
				Thread.Sleep(1);
			}
			foreach (KeyValuePair<int, int> keyValuePair in list)
			{
				byte[] array = new byte[keyValuePair.Value];
				for (int j = 0; j < keyValuePair.Value; j++)
				{
					array[j] = 0;
				}
				util.writeBytes(keyValuePair.Key, array, keyValuePair.Value);
			}
			return new Tuple<uint, ulong>(util.readUInt(this.ret_loc_small), util.readQword(this.ret_loc_large));
		}

		// Token: 0x040000C0 RID: 192
		public static int function_ids;

		// Token: 0x040000C1 RID: 193
		private Dictionary<string, EmRemote.RoutineInfo> routines;

		// Token: 0x040000C2 RID: 194
		private int remote_loc;

		// Token: 0x040000C3 RID: 195
		private int func_id_loc;

		// Token: 0x040000C4 RID: 196
		private int args_loc;

		// Token: 0x040000C5 RID: 197
		private int ret_loc_small;

		// Token: 0x040000C6 RID: 198
		private int ret_loc_large;

		// Token: 0x040000C7 RID: 199
		private int funcs_loc;

		// Token: 0x040000C8 RID: 200
		private int spoofroutine;

		// Token: 0x040000C9 RID: 201
		private int spoofredirect;

		// Token: 0x02000012 RID: 18
		private struct RoutineInfo
		{
			// Token: 0x06000075 RID: 117 RVA: 0x00011900 File Offset: 0x0000FB00
			public RoutineInfo(int _routine, byte _conv)
			{
				this.routine = _routine;
				this.conv = _conv;
				this.id = EmRemote.function_ids++;
			}

			// Token: 0x04000124 RID: 292
			public int routine;

			// Token: 0x04000125 RID: 293
			public byte conv;

			// Token: 0x04000126 RID: 294
			public int id;
		}
	}
}
