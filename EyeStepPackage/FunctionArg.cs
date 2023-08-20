using System;

namespace EyeStepPackage
{
	// Token: 0x02000006 RID: 6
	public class FunctionArg
	{
		// Token: 0x06000025 RID: 37 RVA: 0x0000EC1C File Offset: 0x0000CE1C
		public FunctionArg(int x)
		{
			this.small = x;
			this.type = "smallvalue";
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0000EC36 File Offset: 0x0000CE36
		public FunctionArg(double x)
		{
			this.large = x;
			this.type = "largevalue";
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000EC50 File Offset: 0x0000CE50
		public FunctionArg(string x)
		{
			this.str = x;
			this.type = "string";
		}

		// Token: 0x040000BC RID: 188
		public int small;

		// Token: 0x040000BD RID: 189
		public double large;

		// Token: 0x040000BE RID: 190
		public string str;

		// Token: 0x040000BF RID: 191
		public string type;
	}
}
