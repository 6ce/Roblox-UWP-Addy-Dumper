using System;

namespace EyeStepPackage
{
	// Token: 0x02000004 RID: 4
	public enum OP_TYPES : byte
	{
		// Token: 0x04000016 RID: 22
		AL,
		// Token: 0x04000017 RID: 23
		AH,
		// Token: 0x04000018 RID: 24
		AX,
		// Token: 0x04000019 RID: 25
		EAX,
		// Token: 0x0400001A RID: 26
		ECX,
		// Token: 0x0400001B RID: 27
		EDX,
		// Token: 0x0400001C RID: 28
		ESP,
		// Token: 0x0400001D RID: 29
		EBP,
		// Token: 0x0400001E RID: 30
		CL,
		// Token: 0x0400001F RID: 31
		CX,
		// Token: 0x04000020 RID: 32
		DX,
		// Token: 0x04000021 RID: 33
		Sreg,
		// Token: 0x04000022 RID: 34
		ptr16_32,
		// Token: 0x04000023 RID: 35
		Flags,
		// Token: 0x04000024 RID: 36
		EFlags,
		// Token: 0x04000025 RID: 37
		ES,
		// Token: 0x04000026 RID: 38
		CS,
		// Token: 0x04000027 RID: 39
		DS,
		// Token: 0x04000028 RID: 40
		SS,
		// Token: 0x04000029 RID: 41
		FS,
		// Token: 0x0400002A RID: 42
		GS,
		// Token: 0x0400002B RID: 43
		one,
		// Token: 0x0400002C RID: 44
		r8,
		// Token: 0x0400002D RID: 45
		r16,
		// Token: 0x0400002E RID: 46
		r16_32,
		// Token: 0x0400002F RID: 47
		r32,
		// Token: 0x04000030 RID: 48
		r64,
		// Token: 0x04000031 RID: 49
		r_m8,
		// Token: 0x04000032 RID: 50
		r_m16,
		// Token: 0x04000033 RID: 51
		r_m16_32,
		// Token: 0x04000034 RID: 52
		r_m16_m32,
		// Token: 0x04000035 RID: 53
		r_m32,
		// Token: 0x04000036 RID: 54
		moffs8,
		// Token: 0x04000037 RID: 55
		moffs16_32,
		// Token: 0x04000038 RID: 56
		m16_32_and_16_32,
		// Token: 0x04000039 RID: 57
		m,
		// Token: 0x0400003A RID: 58
		m8,
		// Token: 0x0400003B RID: 59
		m14_28,
		// Token: 0x0400003C RID: 60
		m16,
		// Token: 0x0400003D RID: 61
		m16_32,
		// Token: 0x0400003E RID: 62
		m16_int,
		// Token: 0x0400003F RID: 63
		m32,
		// Token: 0x04000040 RID: 64
		m32_int,
		// Token: 0x04000041 RID: 65
		m32real,
		// Token: 0x04000042 RID: 66
		m64,
		// Token: 0x04000043 RID: 67
		m64real,
		// Token: 0x04000044 RID: 68
		m80real,
		// Token: 0x04000045 RID: 69
		m80dec,
		// Token: 0x04000046 RID: 70
		m94_108,
		// Token: 0x04000047 RID: 71
		m128,
		// Token: 0x04000048 RID: 72
		m512,
		// Token: 0x04000049 RID: 73
		rel8,
		// Token: 0x0400004A RID: 74
		rel16,
		// Token: 0x0400004B RID: 75
		rel16_32,
		// Token: 0x0400004C RID: 76
		rel32,
		// Token: 0x0400004D RID: 77
		imm8,
		// Token: 0x0400004E RID: 78
		imm16,
		// Token: 0x0400004F RID: 79
		imm16_32,
		// Token: 0x04000050 RID: 80
		imm32,
		// Token: 0x04000051 RID: 81
		mm,
		// Token: 0x04000052 RID: 82
		mm_m64,
		// Token: 0x04000053 RID: 83
		xmm,
		// Token: 0x04000054 RID: 84
		xmm0,
		// Token: 0x04000055 RID: 85
		xmm_m32,
		// Token: 0x04000056 RID: 86
		xmm_m64,
		// Token: 0x04000057 RID: 87
		xmm_m128,
		// Token: 0x04000058 RID: 88
		STi,
		// Token: 0x04000059 RID: 89
		ST1,
		// Token: 0x0400005A RID: 90
		ST2,
		// Token: 0x0400005B RID: 91
		ST,
		// Token: 0x0400005C RID: 92
		LDTR,
		// Token: 0x0400005D RID: 93
		GDTR,
		// Token: 0x0400005E RID: 94
		IDTR,
		// Token: 0x0400005F RID: 95
		PMC,
		// Token: 0x04000060 RID: 96
		TR,
		// Token: 0x04000061 RID: 97
		XCR,
		// Token: 0x04000062 RID: 98
		MSR,
		// Token: 0x04000063 RID: 99
		MSW,
		// Token: 0x04000064 RID: 100
		CRn,
		// Token: 0x04000065 RID: 101
		DRn,
		// Token: 0x04000066 RID: 102
		CR0,
		// Token: 0x04000067 RID: 103
		DR0,
		// Token: 0x04000068 RID: 104
		DR1,
		// Token: 0x04000069 RID: 105
		DR2,
		// Token: 0x0400006A RID: 106
		DR3,
		// Token: 0x0400006B RID: 107
		DR4,
		// Token: 0x0400006C RID: 108
		DR5,
		// Token: 0x0400006D RID: 109
		DR6,
		// Token: 0x0400006E RID: 110
		DR7,
		// Token: 0x0400006F RID: 111
		IA32_TIMESTAMP_COUNTER,
		// Token: 0x04000070 RID: 112
		IA32_SYS,
		// Token: 0x04000071 RID: 113
		IA32_BIOS
	}
}
