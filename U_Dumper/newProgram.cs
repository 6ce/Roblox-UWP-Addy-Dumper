using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using EyeStepPackage;

namespace U_Dumper
{
	// Token: 0x02000002 RID: 2
	public class newProgram
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		private static void LogFunction(string Fname, int Address)
		{
			int num = 20 - Fname.Length;
			Console.Write(Fname);
			for (int i = 0; i < num; i++)
			{
				Console.Write(" ");
			}
			Console.Write(": 0x" + Address.ToString("X8").Remove(0, 1) + " " + Environment.NewLine);
			newProgram.AddyCount++;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020BC File Offset: 0x000002BC
		private static void LogFunctionAdvanced(string Fname, string Ftext)
		{
			int num = 20 - Fname.Length;
			Console.Write(Fname);
			for (int i = 0; i < num; i++)
			{
				Console.Write(" ");
			}
			Console.Write(": " + Ftext + Environment.NewLine);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002104 File Offset: 0x00000304
		private static void Main()
		{
			Process.Start("roblox:://");
			Console.Title = "U_Dumper";
			Console.WindowWidth = 120;
			Console.WindowHeight = 30;
			Console.SetWindowPosition(0, 0);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("\n   Credits To U_M9 / Sard\n");
			Console.WriteLine("\n   Waiting For Roblox...\n");
			Thread.Sleep(500);
			if (Process.GetProcessesByName("Windows10Universal").Length != 0)
			{
				EyeStep.open("Windows10Universal.exe");
				string data = EyeStep.read(EyeStep.base_module + 4135).data;
				Console.WriteLine("\n   Roblox Found. Extracting...\n");
				newProgram.Watch.Start();
				int prologue = util.getPrologue(scanner.scan_xrefs("oldResult, moduleRef  = ...", 1).Last<int>());
				List<int> calls = util.getCalls(prologue);
				List<int> calls2 = util.getCalls(util.getPrologue(scanner.scan_xrefs("LuauWatchdog", 1).Last<int>()));
				List<int> calls3 = util.getCalls(util.getPrologue(scanner.scan_xrefs("Current identity is %d", 1).Last<int>()));
				int address = util.prevCall(scanner.scan_xrefs("Script Start", 1).Last<int>(), false, false);
				List<int> calls4 = util.getCalls(address);
				int prologue2 = util.getPrologue(scanner.scan_xrefs("Maximum re-entrancy depth (%i) exceeded calling task.defer", 1).Last<int>());
				int prologue3 = util.getPrologue(scanner.scan("55 8B EC 6A ?? 68 ?? ?? ?? ?? 64 A1 ?? ?? ?? ?? 50 83 EC ?? A1 ?? ?? ?? ?? 33 C5 89 45 EC 56 57 50 8D 45 F4 64 A3 ?? ?? ?? ?? 8B 75 08 C7 45 E8 ?? ?? ?? ??", true, 1, 0, null).Last<int>());
				int prologue4 = util.getPrologue(scanner.scan("55 8B EC 83 E4 ?? 83 EC ?? 8B 45 08 53 56 8B F1 57", true, 1, 0, null).Last<int>());
				Console.ForegroundColor = ConsoleColor.Red;
				if (!newProgram.debugProgram)
				{
					Console.WriteLine("\nDebug is set to false\n\n");
				}
				else
				{
					newProgram.LogFunctionAdvanced("LVM_Load Start", util.raslr(prologue).ToString());
					newProgram.LogFunctionAdvanced("LVM_Load Found", util.raslr(calls[17]).ToString());
					Console.WriteLine("\n");
					List<int> calls5 = util.getCalls(calls[17]);
					for (int i = 0; i < calls5.Count; i++)
					{
						newProgram.LogFunctionAdvanced("LVM_Load_CALL " + i.ToString(), util.getAnalysis(calls5[i]));
					}
					for (int j = 0; j < calls2.Count; j++)
					{
						newProgram.LogFunctionAdvanced("GetScheduler_CALLS " + j.ToString(), util.getAnalysis(calls2[j]));
					}
					for (int k = 0; k < calls3.Count; k++)
					{
						newProgram.LogFunctionAdvanced("Print_CALLS " + k.ToString(), util.getAnalysis(calls3[k]));
					}
					for (int l = 0; l < calls4.Count; l++)
					{
						try
						{
							newProgram.LogFunctionAdvanced("Get_Global_State_CALLS " + l.ToString(), util.getAnalysis(calls4[l]));
						}
						catch
						{
						}
					}
				}
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("\n Found Addresses");
				Console.WriteLine("\n\n");
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("\n RASLR");
				newProgram.LogFunction("GetScheduler ", util.raslr(calls2[2]));
				newProgram.LogFunction("TaskDefer ", util.raslr(prologue2));
				newProgram.LogFunction("TaskSpawn ", util.raslr(prologue3));
				newProgram.LogFunction("LVM_Load ", util.raslr(calls[17]));
				newProgram.LogFunction("Print", util.raslr(calls3[3]));
				newProgram.LogFunction("Get_Global_State", util.raslr(address));
				newProgram.LogFunction("Instance", util.raslr(prologue4));
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("\n ASLR");
				newProgram.LogFunction("GetScheduler ", calls2[2]);
				newProgram.LogFunction("TaskDefer ", util.raslr(prologue2) - 4194304);
				newProgram.LogFunction("TaskSpawn ", util.raslr(prologue3) - 4194304);
				newProgram.LogFunction("LVM_Load ", util.raslr(calls[17]) - 4194304);
				newProgram.LogFunction("Print", util.raslr(calls3[3]) - 4194304);
				newProgram.LogFunction("Get_Global_State", util.raslr(address) - 4194304);
				newProgram.LogFunction("Instance", util.raslr(prologue4) - 4194304);
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.WriteLine("\n\n");
				newProgram.Watch.Stop();
				Console.WriteLine(string.Concat(new string[]
				{
					"  Scanned ",
					newProgram.AddyCount.ToString(),
					" Addresses\nTook ",
					newProgram.Watch.ElapsedMilliseconds.ToString(),
					"ms"
				}));
				foreach (Process process in Process.GetProcessesByName("Windows10Universal"))
				{
					process.Kill();
					process.WaitForExit();
					process.Dispose();
				}
				Console.WriteLine("  Press Enter To Exit...");
				Console.ReadLine();
				return;
			}
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("\n  Roblox Not Found...\n");
			Thread.Sleep(2000);
			Environment.Exit(0);
			Console.ReadLine();
		}

		// Token: 0x04000001 RID: 1
		public static bool debugProgram = true;

		// Token: 0x04000002 RID: 2
		private static Stopwatch Watch = new Stopwatch();

		// Token: 0x04000003 RID: 3
		public static int AddyCount;
	}
}
