using System;
using System.Runtime.InteropServices;

namespace EyeStepPackage
{
	// Token: 0x02000003 RID: 3
	public class imports
	{
		// Token: 0x06000006 RID: 6
		[DllImport("kernel32.dll")]
		public static extern int OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

		// Token: 0x06000007 RID: 7
		[DllImport("kernel32.dll")]
		public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

		// Token: 0x06000008 RID: 8
		[DllImport("kernel32.dll")]
		public static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);

		// Token: 0x06000009 RID: 9
		[DllImport("kernel32.dll")]
		public static extern bool VirtualProtectEx(int hProcess, int lpBaseAddress, int dwSize, uint new_protect, ref uint lpOldProtect);

		// Token: 0x0600000A RID: 10
		[DllImport("kernel32.dll")]
		public static extern int VirtualQueryEx(int hProcess, int lpAddress, out imports.MEMORY_BASIC_INFORMATION lpBuffer, uint dwLength);

		// Token: 0x0600000B RID: 11
		[DllImport("kernel32.dll")]
		public static extern int VirtualAllocEx(int hProcess, int lpAddress, int size, uint allocation_type, uint protect);

		// Token: 0x0600000C RID: 12
		[DllImport("kernel32.dll")]
		public static extern int VirtualFreeEx(int hProcess, int lpAddress, int size, uint allocation_type);

		// Token: 0x0600000D RID: 13
		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		public static extern int GetModuleHandle(string lpModuleName);

		// Token: 0x0600000E RID: 14
		[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int GetProcAddress(int hModule, string procName);

		// Token: 0x0600000F RID: 15
		[DllImport("kernel32.dll")]
		public static extern int CreateRemoteThread(int hProcess, int lpThreadAttributes, uint dwStackSize, int lpStartAddress, int lpParameter, uint dwCreationFlags, out int lpThreadId);

		// Token: 0x04000004 RID: 4
		public const uint PAGE_NOACCESS = 1U;

		// Token: 0x04000005 RID: 5
		public const uint PAGE_READONLY = 2U;

		// Token: 0x04000006 RID: 6
		public const uint PAGE_READWRITE = 4U;

		// Token: 0x04000007 RID: 7
		public const uint PAGE_WRITECOPY = 8U;

		// Token: 0x04000008 RID: 8
		public const uint PAGE_EXECUTE = 16U;

		// Token: 0x04000009 RID: 9
		public const uint PAGE_EXECUTE_READ = 32U;

		// Token: 0x0400000A RID: 10
		public const uint PAGE_EXECUTE_READWRITE = 64U;

		// Token: 0x0400000B RID: 11
		public const uint PAGE_EXECUTE_WRITECOPY = 128U;

		// Token: 0x0400000C RID: 12
		public const uint PAGE_GUARD = 256U;

		// Token: 0x0400000D RID: 13
		public const uint PAGE_NOCACHE = 512U;

		// Token: 0x0400000E RID: 14
		public const uint PAGE_WRITECOMBINE = 1024U;

		// Token: 0x0400000F RID: 15
		public const uint MEM_COMMIT = 4096U;

		// Token: 0x04000010 RID: 16
		public const uint MEM_RESERVE = 8192U;

		// Token: 0x04000011 RID: 17
		public const uint MEM_DECOMMIT = 16384U;

		// Token: 0x04000012 RID: 18
		public const uint MEM_RELEASE = 32768U;

		// Token: 0x04000013 RID: 19
		public const uint PROCESS_WM_READ = 16U;

		// Token: 0x04000014 RID: 20
		public const uint PROCESS_ALL_ACCESS = 2035711U;

		// Token: 0x0200000B RID: 11
		public struct MEMORY_BASIC_INFORMATION
		{
			// Token: 0x040000F9 RID: 249
			public int BaseAddress;

			// Token: 0x040000FA RID: 250
			public int AllocationBase;

			// Token: 0x040000FB RID: 251
			public uint AllocationProtect;

			// Token: 0x040000FC RID: 252
			public int RegionSize;

			// Token: 0x040000FD RID: 253
			public uint State;

			// Token: 0x040000FE RID: 254
			public uint Protect;

			// Token: 0x040000FF RID: 255
			public uint Type;
		}
	}
}
