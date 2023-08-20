using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EyeStepPackage
{
	// Token: 0x02000005 RID: 5
	public class EyeStep
	{
		// Token: 0x06000011 RID: 17 RVA: 0x0000262E File Offset: 0x0000082E
		private static int getm20(byte x)
		{
			return (int)(x % 32);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002634 File Offset: 0x00000834
		private static int getm40(byte x)
		{
			return (int)(x % 64);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x0000263A File Offset: 0x0000083A
		private static int finalreg(byte x)
		{
			return (int)(x % 64 % 8);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002642 File Offset: 0x00000842
		private static int longreg(byte x)
		{
			return (int)(x % 64 / 8);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x0000264C File Offset: 0x0000084C
		public static void init()
		{
			EyeStep.OP_INFO[] array = new EyeStep.OP_INFO[919];
			array[0] = new EyeStep.OP_INFO("00", "add", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.r8
			}, "Add");
			array[1] = new EyeStep.OP_INFO("01", "add", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.r16_32
			}, "Add");
			array[2] = new EyeStep.OP_INFO("02", "add", new OP_TYPES[]
			{
				OP_TYPES.r8,
				OP_TYPES.r_m8
			}, "Add");
			array[3] = new EyeStep.OP_INFO("03", "add", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Add");
			array[4] = new EyeStep.OP_INFO("04", "add", new OP_TYPES[]
			{
				OP_TYPES.AL,
				OP_TYPES.imm8
			}, "Add");
			array[5] = new EyeStep.OP_INFO("05", "add", new OP_TYPES[]
			{
				OP_TYPES.EAX,
				OP_TYPES.imm16_32
			}, "Add");
			array[6] = new EyeStep.OP_INFO("06", "push", new OP_TYPES[]
			{
				OP_TYPES.ES
			}, "Push Extra Segment onto the stack");
			array[7] = new EyeStep.OP_INFO("07", "pop", new OP_TYPES[]
			{
				OP_TYPES.ES
			}, "Pop Extra Segment off of the stack");
			array[8] = new EyeStep.OP_INFO("08", "or", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.r8
			}, "Logical Inclusive OR");
			array[9] = new EyeStep.OP_INFO("09", "or", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.r16_32
			}, "Logical Inclusive OR");
			array[10] = new EyeStep.OP_INFO("0A", "or", new OP_TYPES[]
			{
				OP_TYPES.r8,
				OP_TYPES.r_m8
			}, "Logical Inclusive OR");
			array[11] = new EyeStep.OP_INFO("0B", "or", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Logical Inclusive OR");
			array[12] = new EyeStep.OP_INFO("0C", "or", new OP_TYPES[]
			{
				OP_TYPES.AL,
				OP_TYPES.imm8
			}, "Logical Inclusive OR");
			array[13] = new EyeStep.OP_INFO("0D", "or", new OP_TYPES[]
			{
				OP_TYPES.EAX,
				OP_TYPES.imm16_32
			}, "Logical Inclusive OR");
			array[14] = new EyeStep.OP_INFO("0E", "push", new OP_TYPES[]
			{
				OP_TYPES.CS
			}, "Push Code Segment onto the stack");
			array[15] = new EyeStep.OP_INFO("0F+00+m0", "sldt", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Store Local Descriptor Table Register");
			array[16] = new EyeStep.OP_INFO("0F+00+m1", "str", new OP_TYPES[]
			{
				OP_TYPES.r_m16
			}, "Store Task Register");
			array[17] = new EyeStep.OP_INFO("0F+00+m2", "lldt", new OP_TYPES[]
			{
				OP_TYPES.r_m16
			}, "Load Local Descriptor Table Register");
			array[18] = new EyeStep.OP_INFO("0F+00+m3", "ltr", new OP_TYPES[]
			{
				OP_TYPES.r_m16
			}, "Load Task Register");
			array[19] = new EyeStep.OP_INFO("0F+00+m4", "verr", new OP_TYPES[]
			{
				OP_TYPES.r_m16
			}, "Verify a Segment for Reading");
			array[20] = new EyeStep.OP_INFO("0F+00+m5", "verw", new OP_TYPES[]
			{
				OP_TYPES.r_m16
			}, "Verify a Segment for Writing");
			array[21] = new EyeStep.OP_INFO("0F+01+C1", "vmcall", new OP_TYPES[0], "Call to VM Monitor");
			array[22] = new EyeStep.OP_INFO("0F+01+C2", "vmlaunch", new OP_TYPES[0], "Launch Virtual Machine");
			array[23] = new EyeStep.OP_INFO("0F+01+C3", "vmresume", new OP_TYPES[0], "Resume Virtual Machine");
			array[24] = new EyeStep.OP_INFO("0F+01+C4", "vmxoff", new OP_TYPES[0], "Leave VMX Operation");
			array[25] = new EyeStep.OP_INFO("0F+01+C8", "monitor", new OP_TYPES[0], "Set Up Monitor Address");
			array[26] = new EyeStep.OP_INFO("0F+01+C9", "mwait", new OP_TYPES[0], "Monitor Wait");
			array[27] = new EyeStep.OP_INFO("0F+01+CA", "clac", new OP_TYPES[0], "Clear AC flag in EFLAGS register");
			array[28] = new EyeStep.OP_INFO("0F+01+m0", "sgdt", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Store Global Descriptor Table Register");
			array[29] = new EyeStep.OP_INFO("0F+01+m1", "sidt", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Store Interrupt Descriptor Table Register");
			array[30] = new EyeStep.OP_INFO("0F+01+m2", "lgdt", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Load Global Descriptor Table Register");
			array[31] = new EyeStep.OP_INFO("0F+01+m3", "lidt", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Load Interrupt Descriptor Table Register");
			array[32] = new EyeStep.OP_INFO("0F+01+m4", "smsw", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Store Machine Status Word");
			array[33] = new EyeStep.OP_INFO("0F+01+m5", "smsw", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Store Machine Status Word");
			array[34] = new EyeStep.OP_INFO("0F+01+m6", "lmsw", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Load Machine Status Word");
			array[35] = new EyeStep.OP_INFO("0F+01+m7", "invplg", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Invalidate TLB Entry");
			array[36] = new EyeStep.OP_INFO("0F+02", "lar", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.m16
			}, "Load Access Rights Byte");
			array[37] = new EyeStep.OP_INFO("0F+03", "lsl", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.m16
			}, "Load Segment Limit");
			array[38] = new EyeStep.OP_INFO("0F+04", "ud", new OP_TYPES[0], "Undefined Instruction");
			array[39] = new EyeStep.OP_INFO("0F+05", "syscall", new OP_TYPES[0], "Fast System Call");
			array[40] = new EyeStep.OP_INFO("0F+06", "clts", new OP_TYPES[]
			{
				OP_TYPES.CR0
			}, "Clear Task-Switched Flag in CR0");
			array[41] = new EyeStep.OP_INFO("0F+07", "sysret", new OP_TYPES[0], "Return form fast system call");
			array[42] = new EyeStep.OP_INFO("0F+08", "invd", new OP_TYPES[0], "Invalidate Internal Caches");
			array[43] = new EyeStep.OP_INFO("0F+09", "wbinvd", new OP_TYPES[0], "Write Back and Invalidate Cache");
			array[44] = new EyeStep.OP_INFO("0F+0B", "ud2", new OP_TYPES[0], "Undefined Instruction");
			array[45] = new EyeStep.OP_INFO("0F+0D", "nop", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "No Operation");
			array[46] = new EyeStep.OP_INFO("0F+10", "movups", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Move Unaligned Packed Single-FP Values");
			array[47] = new EyeStep.OP_INFO("F3+0F+10", "movss", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m32
			}, "Move Scalar Single-FP Values");
			array[48] = new EyeStep.OP_INFO("66+0F+10", "movupd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Move Unaligned Packed Double-FP Value");
			array[49] = new EyeStep.OP_INFO("F2+0F+10", "movsd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m64
			}, "Move Scalar Double-FP Value");
			array[50] = new EyeStep.OP_INFO("0F+11", "movups", new OP_TYPES[]
			{
				OP_TYPES.xmm_m128,
				OP_TYPES.xmm
			}, "Move Unaligned Packed Single-FP Values");
			array[51] = new EyeStep.OP_INFO("F3+0F+11", "movss", new OP_TYPES[]
			{
				OP_TYPES.xmm_m32,
				OP_TYPES.xmm
			}, "Move Scalar Single-FP Values");
			array[52] = new EyeStep.OP_INFO("66+0F+11", "movupd", new OP_TYPES[]
			{
				OP_TYPES.xmm_m128,
				OP_TYPES.xmm
			}, "Move Unaligned Packed Double-FP Value");
			array[53] = new EyeStep.OP_INFO("F2+0F+11", "movsd", new OP_TYPES[]
			{
				OP_TYPES.xmm_m64,
				OP_TYPES.xmm
			}, "Move Scalar Double-FP Value");
			array[54] = new EyeStep.OP_INFO("0F+12", "movhlps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm
			}, "Move Packed Single-FP Values High to Low");
			array[55] = new EyeStep.OP_INFO("0F+12", "movlps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.m64
			}, "Move Low Packed Single-FP Values");
			array[56] = new EyeStep.OP_INFO("F3+0F+12", "movlpd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.m64
			}, "Move Low Packed Double-FP Value");
			array[57] = new EyeStep.OP_INFO("66+0F+12", "movddup", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m64
			}, "Move One Double-FP and Duplicate");
			array[58] = new EyeStep.OP_INFO("F2+0F+12", "movsldup", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m64
			}, "Move Packed Single-FP Low and Duplicate");
			array[59] = new EyeStep.OP_INFO("0F+13", "movlps", new OP_TYPES[]
			{
				OP_TYPES.m64,
				OP_TYPES.xmm
			}, "Move Low Packed Single-FP Values");
			array[60] = new EyeStep.OP_INFO("66+0F+13", "movlpd", new OP_TYPES[]
			{
				OP_TYPES.m64,
				OP_TYPES.xmm
			}, "Move Low Packed Double-FP Value");
			array[61] = new EyeStep.OP_INFO("0F+14", "unpcklps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m64
			}, "Unpack and Interleave Low Packed Single-FP Values");
			array[62] = new EyeStep.OP_INFO("66+0F+14", "unpcklpd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Unpack and Interleave Low Packed Double-FP Values");
			array[63] = new EyeStep.OP_INFO("0F+15", "unpckhps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m64
			}, "Unpack and Interleave High Packed Single-FP Values");
			array[64] = new EyeStep.OP_INFO("66+0F+15", "unpckhpd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Unpack and Interleave High Packed Double-FP Values");
			array[65] = new EyeStep.OP_INFO("0F+16", "movlhps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm
			}, "Move Packed Single-FP Values Low to High");
			array[66] = new EyeStep.OP_INFO("0F+16", "movhps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.m64
			}, "Move High Packed Single-FP Values");
			array[67] = new EyeStep.OP_INFO("66+0F+16", "movhpd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.m64
			}, "Move High Packed Double-FP Value");
			array[68] = new EyeStep.OP_INFO("F3+0F+16", "movshdup", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m64
			}, "Move Packed Single-FP High and Duplicate");
			array[69] = new EyeStep.OP_INFO("0F+17", "movhps", new OP_TYPES[]
			{
				OP_TYPES.m64,
				OP_TYPES.xmm
			}, "Move High Packed Single-FP Values");
			array[70] = new EyeStep.OP_INFO("66+0F+17", "movhpd", new OP_TYPES[]
			{
				OP_TYPES.m64,
				OP_TYPES.xmm
			}, "Move High Packed Double-FP Value");
			array[71] = new EyeStep.OP_INFO("0F+18+m0", "prefetchnta", new OP_TYPES[]
			{
				OP_TYPES.m8
			}, "Prefetch Data Into Caches");
			array[72] = new EyeStep.OP_INFO("0F+18+m1", "prefetcht0", new OP_TYPES[]
			{
				OP_TYPES.m8
			}, "Prefetch Data Into Caches");
			array[73] = new EyeStep.OP_INFO("0F+18+m2", "prefetcht1", new OP_TYPES[]
			{
				OP_TYPES.m8
			}, "Prefetch Data Into Caches");
			array[74] = new EyeStep.OP_INFO("0F+18+m3", "prefetcht2", new OP_TYPES[]
			{
				OP_TYPES.m8
			}, "Prefetch Data Into Caches");
			array[75] = new EyeStep.OP_INFO("0F+18+m4", "hint_nop", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Hintable NOP");
			array[76] = new EyeStep.OP_INFO("0F+18+m5", "hint_nop", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Hintable NOP");
			array[77] = new EyeStep.OP_INFO("0F+18+m6", "hint_nop", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Hintable NOP");
			array[78] = new EyeStep.OP_INFO("0F+18+m7", "hint_nop", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Hintable NOP");
			array[79] = new EyeStep.OP_INFO("0F+19", "hint_nop", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Hintable NOP");
			array[80] = new EyeStep.OP_INFO("0F+1A", "hint_nop", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Hintable NOP");
			array[81] = new EyeStep.OP_INFO("0F+1B", "hint_nop", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Hintable NOP");
			array[82] = new EyeStep.OP_INFO("0F+1C", "hint_nop", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Hintable NOP");
			array[83] = new EyeStep.OP_INFO("0F+1D", "hint_nop", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Hintable NOP");
			array[84] = new EyeStep.OP_INFO("0F+1E", "hint_nop", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Hintable NOP");
			array[85] = new EyeStep.OP_INFO("0F+1F+m0", "nop", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "No Operation");
			array[86] = new EyeStep.OP_INFO("0F+1F+m1", "hint_nop", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Hintable NOP");
			array[87] = new EyeStep.OP_INFO("0F+1F+m2", "hint_nop", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Hintable NOP");
			array[88] = new EyeStep.OP_INFO("0F+1F+m3", "hint_nop", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Hintable NOP");
			array[89] = new EyeStep.OP_INFO("0F+1F+m4", "hint_nop", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Hintable NOP");
			array[90] = new EyeStep.OP_INFO("0F+1F+m5", "hint_nop", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Hintable NOP");
			array[91] = new EyeStep.OP_INFO("0F+1F+m6", "hint_nop", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Hintable NOP");
			array[92] = new EyeStep.OP_INFO("0F+1F+m7", "hint_nop", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Hintable NOP");
			array[93] = new EyeStep.OP_INFO("0F+20", "mov", new OP_TYPES[]
			{
				OP_TYPES.r_m32,
				OP_TYPES.CRn
			}, "Move to/from Control Registers");
			array[94] = new EyeStep.OP_INFO("0F+21", "mov", new OP_TYPES[]
			{
				OP_TYPES.r_m32,
				OP_TYPES.DRn
			}, "Move to/from Debug Registers");
			array[95] = new EyeStep.OP_INFO("0F+22", "mov", new OP_TYPES[]
			{
				OP_TYPES.CRn,
				OP_TYPES.r_m32
			}, "Move to/from Control Registers");
			array[96] = new EyeStep.OP_INFO("0F+23", "mov", new OP_TYPES[]
			{
				OP_TYPES.DRn,
				OP_TYPES.r_m32
			}, "Move to/from Debug Registers");
			array[97] = new EyeStep.OP_INFO("0F+28", "movaps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Move Aligned Packed Single-FP Values");
			array[98] = new EyeStep.OP_INFO("66+0F+28", "movapd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Move Aligned Packed Double-FP Values");
			array[99] = new EyeStep.OP_INFO("0F+29", "movaps", new OP_TYPES[]
			{
				OP_TYPES.xmm_m128,
				OP_TYPES.xmm
			}, "Move Aligned Packed Single-FP Values");
			array[100] = new EyeStep.OP_INFO("66+0F+29", "movapd", new OP_TYPES[]
			{
				OP_TYPES.xmm_m128,
				OP_TYPES.xmm
			}, "Move Aligned Packed Double-FP Values");
			array[101] = new EyeStep.OP_INFO("0F+2A", "cvtpi2ps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.mm_m64
			}, "Convert Packed DW Integers to Single-FP Values");
			array[102] = new EyeStep.OP_INFO("F3+0F+2A", "cvtpi2ss", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.r_m32
			}, "Convert DW Integer to Scalar Single-FP Value");
			array[103] = new EyeStep.OP_INFO("66+0F+2A", "cvtpi2pd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.mm_m64
			}, "Convert Packed DW Integers to Double-FP Values");
			array[104] = new EyeStep.OP_INFO("F2+0F+2A", "cvtpi2sd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.r_m32
			}, "Convert DW Integer to Scalar Double-FP Value");
			array[105] = new EyeStep.OP_INFO("0F+2B", "movntps", new OP_TYPES[]
			{
				OP_TYPES.m128,
				OP_TYPES.xmm
			}, "Store Packed Single-FP Values Using Non-Temporal Hint");
			array[106] = new EyeStep.OP_INFO("66+0F+2B", "movntpd", new OP_TYPES[]
			{
				OP_TYPES.m128,
				OP_TYPES.xmm
			}, "Store Packed Double-FP Values Using Non-Temporal Hint");
			array[107] = new EyeStep.OP_INFO("0F+2C", "cvttps2pi", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.xmm_m64
			}, "Convert with Trunc. Packed Single-FP Values to DW Integers");
			array[108] = new EyeStep.OP_INFO("F3+0F+2C", "cvttss2si", new OP_TYPES[]
			{
				OP_TYPES.r32,
				OP_TYPES.xmm_m32
			}, "Convert with Trunc. Scalar Single-FP Value to DW Integer");
			array[109] = new EyeStep.OP_INFO("66+0F+2C", "cvttpd2pi", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.xmm_m128
			}, "Convert with Trunc. Packed Double-FP Values to DW Integers");
			array[110] = new EyeStep.OP_INFO("F2+0F+2C", "cvttsd2si", new OP_TYPES[]
			{
				OP_TYPES.r32,
				OP_TYPES.xmm_m64
			}, "Convert with Trunc. Scalar Double-FP Value to Signed DW Int");
			array[111] = new EyeStep.OP_INFO("0F+2D", "cvtps2pi", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.xmm_m64
			}, "Convert Packed Single-FP Values to DW Integers");
			array[112] = new EyeStep.OP_INFO("F3+0F+2D", "cvtss2si", new OP_TYPES[]
			{
				OP_TYPES.r32,
				OP_TYPES.xmm_m32
			}, "Convert Scalar Single-FP Value to DW Integer");
			array[113] = new EyeStep.OP_INFO("66+0F+2D", "cvtpd2pi", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.xmm_m128
			}, "Convert Packed Double-FP Values to DW Integers");
			array[114] = new EyeStep.OP_INFO("F2+0F+2D", "cvtsd2si", new OP_TYPES[]
			{
				OP_TYPES.r32,
				OP_TYPES.xmm_m64
			}, "Convert Scalar Double-FP Value to DW Integer");
			array[115] = new EyeStep.OP_INFO("0F+2E", "ucomiss", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m32
			}, "Unordered Compare Scalar Ordered Single-FP Values and Set EFLAGS");
			array[116] = new EyeStep.OP_INFO("66+0F+2E", "ucomisd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m64
			}, "Unordered Compare Scalar Ordered Double-FP Values and Set EFLAGS");
			array[117] = new EyeStep.OP_INFO("0F+2F", "comiss", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m32
			}, "Compare Scalar Ordered Single-FP Values and Set EFLAGS");
			array[118] = new EyeStep.OP_INFO("66+0F+2F", "comisd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m64
			}, "Compare Scalar Ordered Double-FP Values and Set EFLAGS");
			array[119] = new EyeStep.OP_INFO("0F+30", "wrmsr", new OP_TYPES[0], "Write to Model Specific Register");
			array[120] = new EyeStep.OP_INFO("0F+31", "rdtsc", new OP_TYPES[0], "Read Time-Stamp Counter");
			array[121] = new EyeStep.OP_INFO("0F+32", "rdmsr", new OP_TYPES[0], "Read from Model Specific Register");
			array[122] = new EyeStep.OP_INFO("0F+33", "rdpmc", new OP_TYPES[0], "Read Performance-Monitoring Counters");
			array[123] = new EyeStep.OP_INFO("0F+34", "sysenter", new OP_TYPES[0], "Fast System Call");
			array[124] = new EyeStep.OP_INFO("0F+35", "sysexit", new OP_TYPES[0], "Fast Return from Fast System Call");
			array[125] = new EyeStep.OP_INFO("0F+37", "getsec", new OP_TYPES[0], "GETSEC Leaf Functions");
			array[126] = new EyeStep.OP_INFO("0F+38+00", "pshufb", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Packed Shuffle Bytes");
			array[127] = new EyeStep.OP_INFO("66+0F+38+00", "pshufb", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Packed Shuffle Bytes");
			array[128] = new EyeStep.OP_INFO("0F+38+01", "phaddw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Packed Horizontal Add");
			array[129] = new EyeStep.OP_INFO("66+0F+38+01", "phaddw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Packed Horizontal Add");
			array[130] = new EyeStep.OP_INFO("0F+38+02", "phaddd", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Packed Horizontal Add");
			array[131] = new EyeStep.OP_INFO("66+0F+38+02", "phaddd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Packed Horizontal Add");
			array[132] = new EyeStep.OP_INFO("0F+38+03", "phaddsw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Packed Horizontal Add and Saturate");
			array[133] = new EyeStep.OP_INFO("66+0F+38+03", "phaddsw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Packed Horizontal Add and Saturate");
			array[134] = new EyeStep.OP_INFO("0F+38+04", "pmaddubsw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Multiply and Add Packed Signed and Unsigned Bytes");
			array[135] = new EyeStep.OP_INFO("66+0F+38+04", "pmaddubsw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Multiply and Add Packed Signed and Unsigned Bytes");
			array[136] = new EyeStep.OP_INFO("0F+38+05", "phsubw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Packed Horizontal Subtract");
			array[137] = new EyeStep.OP_INFO("66+0F+38+05", "phsubw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Packed Horizontal Subtract");
			array[138] = new EyeStep.OP_INFO("0F+38+06", "phsubd", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Packed Horizontal Subtract");
			array[139] = new EyeStep.OP_INFO("66+0F+38+06", "phsubd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Packed Horizontal Subtract");
			array[140] = new EyeStep.OP_INFO("0F+38+07", "phsubsw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Packed Horizontal Subtract and Saturate");
			array[141] = new EyeStep.OP_INFO("66+0F+38+07", "phsubsw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Packed Horizontal Subtract and Saturate");
			array[142] = new EyeStep.OP_INFO("0F+38+08", "psignb", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Packed SIGN");
			array[143] = new EyeStep.OP_INFO("66+0F+38+08", "psignb", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Packed SIGN");
			array[144] = new EyeStep.OP_INFO("0F+38+09", "psignw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Packed SIGN");
			array[145] = new EyeStep.OP_INFO("66+0F+38+09", "psignw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Packed SIGN");
			array[146] = new EyeStep.OP_INFO("0F+38+0A", "psignd", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Packed SIGN");
			array[147] = new EyeStep.OP_INFO("66+0F+38+0A", "psignd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Packed SIGN");
			array[148] = new EyeStep.OP_INFO("0F+38+0B", "pmulhrsw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Packed Multiply High with Round and Scale");
			array[149] = new EyeStep.OP_INFO("66+0F+38+0B", "pmulhrsw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Packed Multiply High with Round and Scale");
			array[150] = new EyeStep.OP_INFO("66+0F+38+10", "pblendvb", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128,
				OP_TYPES.xmm0
			}, "Variable Blend Packed Bytes");
			array[151] = new EyeStep.OP_INFO("66+0F+38+14", "blendvps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128,
				OP_TYPES.xmm0
			}, "Variable Blend Packed Single-FP Values");
			array[152] = new EyeStep.OP_INFO("66+0F+38+15", "blendvpd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128,
				OP_TYPES.xmm0
			}, "Variable Blend Packed Double-FP Values");
			array[153] = new EyeStep.OP_INFO("66+0F+38+17", "ptest", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Logical Compare");
			array[154] = new EyeStep.OP_INFO("0F+38+1C", "pabsb", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Packed Absolute Value");
			array[155] = new EyeStep.OP_INFO("66+0F+38+1C", "pabsb", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Packed Absolute Value");
			array[156] = new EyeStep.OP_INFO("0F+38+1D", "pabsw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Packed Absolute Value");
			array[157] = new EyeStep.OP_INFO("66+0F+38+1D", "pabsw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Packed Absolute Value");
			array[158] = new EyeStep.OP_INFO("0F+38+1E", "pabsd", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Packed Absolute Value");
			array[159] = new EyeStep.OP_INFO("66+0F+38+1E", "pabsd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Packed Absolute Value");
			array[160] = new EyeStep.OP_INFO("66+0F+38+20", "pmovsxbw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.m64
			}, "Packed Move with Sign Extend");
			array[161] = new EyeStep.OP_INFO("66+0F+38+21", "pmovsxbd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.m32
			}, "Packed Move with Sign Extend");
			array[162] = new EyeStep.OP_INFO("66+0F+38+22", "pmovsxbq", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.m16
			}, "Packed Move with Sign Extend");
			array[163] = new EyeStep.OP_INFO("66+0F+38+23", "pmovsxbd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.m64
			}, "Packed Move with Sign Extend");
			array[164] = new EyeStep.OP_INFO("66+0F+38+24", "pmovsxbq", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.m32
			}, "Packed Move with Sign Extend");
			array[165] = new EyeStep.OP_INFO("66+0F+38+25", "pmovsxdq", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.m64
			}, "Packed Move with Sign Extend");
			array[166] = new EyeStep.OP_INFO("66+0F+38+28", "pmuldq", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Multiply Packed Signed Dword Integers");
			array[167] = new EyeStep.OP_INFO("66+0F+38+29", "pcmpeqq", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Compare Packed Qword Data for Equal");
			array[168] = new EyeStep.OP_INFO("66+0F+38+2A", "movntdqa", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.m128
			}, "Load Double Quadword Non-Temporal Aligned Hint");
			array[169] = new EyeStep.OP_INFO("66+0F+38+2B", "packusdw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Pack with Unsigned Saturation");
			array[170] = new EyeStep.OP_INFO("66+0F+38+30", "pmovzxbw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.m64
			}, "Packed Move with Zero Extend");
			array[171] = new EyeStep.OP_INFO("66+0F+38+31", "pmovzxbd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.m32
			}, "Packed Move with Zero Extend");
			array[172] = new EyeStep.OP_INFO("66+0F+38+32", "pmovzxbq", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.m16
			}, "Packed Move with Zero Extend");
			array[173] = new EyeStep.OP_INFO("66+0F+38+33", "pmovzxbd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.m64
			}, "Packed Move with Zero Extend");
			array[174] = new EyeStep.OP_INFO("66+0F+38+34", "pmovzxbq", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.m32
			}, "Packed Move with Zero Extend");
			array[175] = new EyeStep.OP_INFO("66+0F+38+35", "pmovzxbq", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.m64
			}, "Packed Move with Zero Extend");
			array[176] = new EyeStep.OP_INFO("66+0F+38+37", "pcmpgtq", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Compare Packed Qword Data for Greater Than");
			array[177] = new EyeStep.OP_INFO("66+0F+38+38", "pminsb", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Minimum of Packed Signed Byte Integers");
			array[178] = new EyeStep.OP_INFO("66+0F+38+39", "pminsd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Minimum of Packed Signed Dword Integers");
			array[179] = new EyeStep.OP_INFO("66+0F+38+3A", "pminuw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Minimum of Packed Unsigned Word Integers");
			array[180] = new EyeStep.OP_INFO("66+0F+38+3B", "pminud", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Minimum of Packed Unsigned Dword Integers");
			array[181] = new EyeStep.OP_INFO("66+0F+38+3C", "pmaxsb", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Maximum of Packed Signed Byte Integers");
			array[182] = new EyeStep.OP_INFO("66+0F+38+3D", "pmaxsd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Maximum of Packed Signed Dword Integers");
			array[183] = new EyeStep.OP_INFO("66+0F+38+3E", "pmaxuw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Maximum of Packed Unsigned Word Integers");
			array[184] = new EyeStep.OP_INFO("66+0F+38+3F", "pmaxud", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Maximum of Packed Unsigned Dword Integers");
			array[185] = new EyeStep.OP_INFO("66+0F+38+40", "pmulld", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Multiply Packed Signed Dword Integers and Store Low Result");
			array[186] = new EyeStep.OP_INFO("66+0F+38+41", "phminposuw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Packed Horizontal Word Minimum");
			array[187] = new EyeStep.OP_INFO("66+0F+38+80", "invept", new OP_TYPES[]
			{
				OP_TYPES.r32,
				OP_TYPES.m128
			}, "Invalidate Translations Derived from EPT");
			array[188] = new EyeStep.OP_INFO("66+0F+38+81", "invvpid", new OP_TYPES[]
			{
				OP_TYPES.r32,
				OP_TYPES.m128
			}, "Invalidate Translations Based on VPID");
			array[189] = new EyeStep.OP_INFO("0F+38+F0", "movbe", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.m16_32
			}, "Move Data After Swapping Bytes");
			array[190] = new EyeStep.OP_INFO("F2+0F+38+F0", "crc32", new OP_TYPES[]
			{
				OP_TYPES.r32,
				OP_TYPES.r_m8
			}, "Accumulate CRC32 Value");
			array[191] = new EyeStep.OP_INFO("0F+38+F1", "movbe", new OP_TYPES[]
			{
				OP_TYPES.m16_32,
				OP_TYPES.r16_32
			}, "Move Data After Swapping Bytes");
			array[192] = new EyeStep.OP_INFO("F2+0F+38+F1", "crc32", new OP_TYPES[]
			{
				OP_TYPES.r32,
				OP_TYPES.r_m16_32
			}, "Accumulate CRC32 Value");
			array[193] = new EyeStep.OP_INFO("66+0F+3A+08", "roundps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128,
				OP_TYPES.imm8
			}, "Round Packed Single-FP Values");
			array[194] = new EyeStep.OP_INFO("66+0F+3A+09", "roundpd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128,
				OP_TYPES.imm8
			}, "Round Packed Double-FP Values");
			array[195] = new EyeStep.OP_INFO("66+0F+3A+0A", "roundss", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m32,
				OP_TYPES.imm8
			}, "Round Scalar Single-FP Values");
			array[196] = new EyeStep.OP_INFO("66+0F+3A+0B", "roundsd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m64,
				OP_TYPES.imm8
			}, "Round Scalar Double-FP Values");
			array[197] = new EyeStep.OP_INFO("66+0F+3A+0C", "blendps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128,
				OP_TYPES.imm8
			}, "Round Packed Single-FP Values");
			array[198] = new EyeStep.OP_INFO("66+0F+3A+0D", "blendpd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128,
				OP_TYPES.imm8
			}, "Round Packed Double-FP Values");
			array[199] = new EyeStep.OP_INFO("66+0F+3A+0E", "pblendw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128,
				OP_TYPES.imm8
			}, "Blend Packed Words");
			array[200] = new EyeStep.OP_INFO("0F+3A+0F", "palignr", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Packed Align Right");
			array[201] = new EyeStep.OP_INFO("66+0F+3A+0F", "palignr", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.xmm_m128
			}, "Packed Align Right");
			array[202] = new EyeStep.OP_INFO("66+0F+3A+14", "pextrb", new OP_TYPES[]
			{
				OP_TYPES.m8,
				OP_TYPES.xmm,
				OP_TYPES.imm8
			}, "Extract Byte");
			array[203] = new EyeStep.OP_INFO("66+0F+3A+15", "pextrw", new OP_TYPES[]
			{
				OP_TYPES.m16,
				OP_TYPES.xmm,
				OP_TYPES.imm8
			}, "Extract Word");
			array[204] = new EyeStep.OP_INFO("66+0F+3A+16", "pextrd", new OP_TYPES[]
			{
				OP_TYPES.m32,
				OP_TYPES.xmm,
				OP_TYPES.imm8
			}, "Extract Dword/Qword");
			array[205] = new EyeStep.OP_INFO("66+0F+3A+17", "extractps", new OP_TYPES[]
			{
				OP_TYPES.m64,
				OP_TYPES.xmm,
				OP_TYPES.imm8
			}, "Extract Packed Single-FP Value");
			array[206] = new EyeStep.OP_INFO("66+0F+3A+20", "pinsrb", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.m8,
				OP_TYPES.imm8
			}, "Insert Byte");
			array[207] = new EyeStep.OP_INFO("66+0F+3A+21", "insertps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.m32,
				OP_TYPES.imm8
			}, "Insert Packed Single-FP Value");
			array[208] = new EyeStep.OP_INFO("66+0F+3A+22", "pinsrd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.m64,
				OP_TYPES.imm8
			}, "Insert Dword/Qword");
			array[209] = new EyeStep.OP_INFO("66+0F+3A+40", "dpps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Dot Product of Packed Single-FP Values");
			array[210] = new EyeStep.OP_INFO("66+0F+3A+41", "dppd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Dot Product of Packed Double-FP Values");
			array[211] = new EyeStep.OP_INFO("66+0F+3A+42", "mpsadbw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128,
				OP_TYPES.imm8
			}, "Compute Multiple Packed Sums of Absolute Difference");
			array[212] = new EyeStep.OP_INFO("66+0F+3A+60", "pcmpestrm", new OP_TYPES[]
			{
				OP_TYPES.xmm0,
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Packed Compare Explicit Length Strings, Return Mask");
			array[213] = new EyeStep.OP_INFO("66+0F+3A+61", "pcmpestri", new OP_TYPES[]
			{
				OP_TYPES.ECX,
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Packed Compare Explicit Length Strings, Return Index");
			array[214] = new EyeStep.OP_INFO("66+0F+3A+62", "pcmpistrm", new OP_TYPES[]
			{
				OP_TYPES.xmm0,
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128,
				OP_TYPES.imm8
			}, "Packed Compare Implicit Length Strings, Return Mask");
			array[215] = new EyeStep.OP_INFO("66+0F+3A+63", "pcmpistri", new OP_TYPES[]
			{
				OP_TYPES.ECX,
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128,
				OP_TYPES.imm8
			}, "Packed Compare Implicit Length Strings, Return Index");
			array[216] = new EyeStep.OP_INFO("0F+40", "cmovo", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Conditional Move - overflow (OF=1)");
			array[217] = new EyeStep.OP_INFO("0F+41", "cmovno", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Conditional Move - not overflow (OF=0)");
			array[218] = new EyeStep.OP_INFO("0F+42", "cmovb", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Conditional Move - below/not above or equal/carry (CF=1)");
			array[219] = new EyeStep.OP_INFO("0F+43", "cmovnb", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Conditional Move - onot below/above or equal/not carry (CF=0)");
			array[220] = new EyeStep.OP_INFO("0F+44", "cmove", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Conditional Move - zero/equal (ZF=1)");
			array[221] = new EyeStep.OP_INFO("0F+45", "cmovne", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Conditional Move - not zero/not equal (ZF=0)");
			array[222] = new EyeStep.OP_INFO("0F+46", "cmovbe", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Conditional Move - below or equal/not above (CF=1 OR ZF=1)");
			array[223] = new EyeStep.OP_INFO("0F+47", "cmova", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Conditional Move - not below or equal/above (CF=0 AND ZF=0)");
			array[224] = new EyeStep.OP_INFO("0F+48", "cmovs", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Conditional Move - sign (SF=1)");
			array[225] = new EyeStep.OP_INFO("0F+49", "cmovns", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Conditional Move - not sign (SF=0)");
			array[226] = new EyeStep.OP_INFO("0F+4A", "cmovp", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Conditional Move - parity/parity even (PF=1)");
			array[227] = new EyeStep.OP_INFO("0F+4B", "cmovnp", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Conditional Move - not parity/parity odd (PF=0)");
			array[228] = new EyeStep.OP_INFO("0F+4C", "cmovl", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Conditional Move - less/not greater (SF!=OF)");
			array[229] = new EyeStep.OP_INFO("0F+4D", "cmovge", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Conditional Move - not less/greater or equal (SF=OF)");
			array[230] = new EyeStep.OP_INFO("0F+4E", "cmovng", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Conditional Move - less or equal/not greater ((ZF=1) OR (SF!=OF))");
			array[231] = new EyeStep.OP_INFO("0F+4F", "cmovg", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Conditional Move - not less nor equal/greater ((ZF=0) AND (SF=OF))");
			array[232] = new EyeStep.OP_INFO("0F+50", "movmskps", new OP_TYPES[]
			{
				OP_TYPES.r32,
				OP_TYPES.xmm
			}, "Extract Packed Single-FP Sign Mask");
			array[233] = new EyeStep.OP_INFO("66+0F+50", "movmskpd", new OP_TYPES[]
			{
				OP_TYPES.r32,
				OP_TYPES.xmm
			}, "Extract Packed Double-FP Sign Mask");
			array[234] = new EyeStep.OP_INFO("66+0F+50", "movmskpd", new OP_TYPES[]
			{
				OP_TYPES.r32,
				OP_TYPES.xmm
			}, "Extract Packed Double-FP Sign Mask");
			array[235] = new EyeStep.OP_INFO("0F+51", "sqrtps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Compute Square Roots of Packed Single-FP Values");
			array[236] = new EyeStep.OP_INFO("F3+0F+51", "sqrtss", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m32
			}, "Compute Square Root of Scalar Single-FP Value");
			array[237] = new EyeStep.OP_INFO("66+0F+51", "sqrtpd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Compute Square Roots of Packed Double-FP Values");
			array[238] = new EyeStep.OP_INFO("F2+0F+51", "sqrtsd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m64
			}, "Compute Square Root of Scalar Double-FP Value");
			array[239] = new EyeStep.OP_INFO("0F+52", "rsqrtps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Compute Recipr. of Square Roots of Packed Single-FP Values");
			array[240] = new EyeStep.OP_INFO("F3+0F+52", "rsqrtss", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m32
			}, "Compute Recipr. of Square Root of Scalar Single-FP Value");
			array[241] = new EyeStep.OP_INFO("0F+53", "rcpps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Compute Reciprocals of Packed Single-FP Values");
			array[242] = new EyeStep.OP_INFO("F3+0F+53", "rcpss", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m32
			}, "Compute Reciprocal of Scalar Single-FP Values");
			array[243] = new EyeStep.OP_INFO("0F+54", "andps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Bitwise Logical AND of Packed Single-FP Values");
			array[244] = new EyeStep.OP_INFO("66+0F+54", "andpd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Bitwise Logical AND of Packed Double-FP Values");
			array[245] = new EyeStep.OP_INFO("0F+55", "andnps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Bitwise Logical AND NOT of Packed Single-FP Values");
			array[246] = new EyeStep.OP_INFO("66+0F+55", "andnpd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Bitwise Logical AND NOT of Packed Double-FP Values");
			array[247] = new EyeStep.OP_INFO("0F+56", "orps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Bitwise Logical OR of Packed Single-FP Values");
			array[248] = new EyeStep.OP_INFO("66+0F+56", "orpd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Bitwise Logical OR of Packed Double-FP Values");
			array[249] = new EyeStep.OP_INFO("0F+57", "xorps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Bitwise Logical XOR of Packed Single-FP Values");
			array[250] = new EyeStep.OP_INFO("66+0F+57", "xorpd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Bitwise Logical XOR of Packed Double-FP Values");
			array[251] = new EyeStep.OP_INFO("0F+58", "addps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Add Packed Single-FP Values");
			array[252] = new EyeStep.OP_INFO("F3+0F+58", "addss", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m32
			}, "Add Scalar Single-FP Values");
			array[253] = new EyeStep.OP_INFO("66+0F+58", "addpd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Add Packed Double-FP Values");
			array[254] = new EyeStep.OP_INFO("F2+0F+58", "addsd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m64
			}, "Add Scalar Double-FP Values");
			array[255] = new EyeStep.OP_INFO("0F+59", "mulps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Multiply Packed Single-FP Values");
			array[256] = new EyeStep.OP_INFO("F3+0F+59", "mulss", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m32
			}, "Multiply Scalar Single-FP Value");
			array[257] = new EyeStep.OP_INFO("66+0F+59", "mulpd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Multiply Packed Double-FP Values");
			array[258] = new EyeStep.OP_INFO("F2+0F+59", "addsd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m64
			}, "Multiply Scalar Double-FP Values");
			array[259] = new EyeStep.OP_INFO("0F+5A", "cvtps2pd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Convert Packed Single-FP Values to Double-FP Values");
			array[260] = new EyeStep.OP_INFO("F3+0F+5A", "cvtpd2ps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Convert Packed Double-FP Values to Single-FP Values");
			array[261] = new EyeStep.OP_INFO("66+0F+5A", "cvtss2sd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m32
			}, "Convert Scalar Single-FP Value to Scalar Double-FP Value");
			array[262] = new EyeStep.OP_INFO("F2+0F+5A", "cvtsd2ss", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m64
			}, "Convert Scalar Double-FP Value to Scalar Single-FP Value");
			array[263] = new EyeStep.OP_INFO("0F+5B", "cvtdq2ps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Convert Packed DW Integers to Single-FP Values");
			array[264] = new EyeStep.OP_INFO("66+0F+5B", "cvtps2dq", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Convert Packed Single-FP Values to DW Integers");
			array[265] = new EyeStep.OP_INFO("F3+0F+5B", "cvttps2dq", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Convert with Trunc. Packed Single-FP Values to DW Integers");
			array[266] = new EyeStep.OP_INFO("0F+5C", "subps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Subtract Packed Single-FP Values");
			array[267] = new EyeStep.OP_INFO("F3+0F+5C", "subss", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m32
			}, "Subtract Scalar Single-FP Values");
			array[268] = new EyeStep.OP_INFO("66+0F+5C", "subpd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Subtract Packed Double-FP Values");
			array[269] = new EyeStep.OP_INFO("F2+0F+5C", "subsd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m64
			}, "Subtract Scalar Double-FP Values");
			array[270] = new EyeStep.OP_INFO("0F+5D", "minps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Return Minimum Packed Single-FP Values");
			array[271] = new EyeStep.OP_INFO("F3+0F+5D", "minss", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m32
			}, "Return Minimum Scalar Single-FP Values");
			array[272] = new EyeStep.OP_INFO("66+0F+5D", "minpd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Return Minimum Packed Double-FP Values");
			array[273] = new EyeStep.OP_INFO("F2+0F+5D", "minsd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m64
			}, "Return Minimum Scalar Double-FP Values");
			array[274] = new EyeStep.OP_INFO("0F+5E", "divps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Divide Packed Single-FP Values");
			array[275] = new EyeStep.OP_INFO("F3+0F+5E", "divss", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m32
			}, "Divide Scalar Single-FP Values");
			array[276] = new EyeStep.OP_INFO("66+0F+5E", "divpd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Divide Packed Double-FP Values");
			array[277] = new EyeStep.OP_INFO("F2+0F+5E", "divsd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m64
			}, "Divide Scalar Double-FP Values");
			array[278] = new EyeStep.OP_INFO("0F+5F", "maxps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Return Maximum Packed Single-FP Values");
			array[279] = new EyeStep.OP_INFO("F3+0F+5F", "maxss", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m32
			}, "Return Maximum Scalar Single-FP Values");
			array[280] = new EyeStep.OP_INFO("66+0F+5F", "maxpd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Return Maximum Packed Double-FP Values");
			array[281] = new EyeStep.OP_INFO("F2+0F+5F", "maxsd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m64
			}, "Return Maximum Scalar Double-FP Values");
			array[282] = new EyeStep.OP_INFO("0F+60", "punpcklbw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Unpack Low Data");
			array[283] = new EyeStep.OP_INFO("66+0F+60", "punpcklbw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Unpack Low Data");
			array[284] = new EyeStep.OP_INFO("0F+61", "punpcklbd", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Unpack Low Data");
			array[285] = new EyeStep.OP_INFO("66+0F+61", "punpcklbd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Unpack Low Data");
			array[286] = new EyeStep.OP_INFO("0F+62", "punpcklbq", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Unpack Low Data");
			array[287] = new EyeStep.OP_INFO("66+0F+62", "punpcklbq", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Unpack Low Data");
			array[288] = new EyeStep.OP_INFO("0F+63", "packsswb", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Pack with Signed Saturation");
			array[289] = new EyeStep.OP_INFO("66+0F+63", "packsswb", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Pack with Signed Saturation");
			array[290] = new EyeStep.OP_INFO("0F+64", "pcmpgtb", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Compare Packed Signed Integers for Greater Than");
			array[291] = new EyeStep.OP_INFO("66+0F+64", "pcmpgtb", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Compare Packed Signed Integers for Greater Than");
			array[292] = new EyeStep.OP_INFO("0F+65", "pcmpgtw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Compare Packed Signed Integers for Greater Than");
			array[293] = new EyeStep.OP_INFO("66+0F+65", "pcmpgtw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Compare Packed Signed Integers for Greater Than");
			array[294] = new EyeStep.OP_INFO("0F+66", "pcmpgtd", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Compare Packed Signed Integers for Greater Than");
			array[295] = new EyeStep.OP_INFO("66+0F+66", "pcmpgtd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Compare Packed Signed Integers for Greater Than");
			array[296] = new EyeStep.OP_INFO("0F+67", "packuswb", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Pack with Unsigned Saturation");
			array[297] = new EyeStep.OP_INFO("66+0F+67", "packuswb", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Pack with Unsigned Saturation");
			array[298] = new EyeStep.OP_INFO("0F+68", "punpckhbw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Unpack High Data");
			array[299] = new EyeStep.OP_INFO("66+0F+68", "punpckhbw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Unpack High Data");
			array[300] = new EyeStep.OP_INFO("0F+69", "punpckhwd", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Unpack High Data");
			array[301] = new EyeStep.OP_INFO("66+0F+69", "punpckhwd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Unpack High Data");
			array[302] = new EyeStep.OP_INFO("0F+6A", "punpckhdq", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Unpack High Data");
			array[303] = new EyeStep.OP_INFO("66+0F+6A", "punpckhdq", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Unpack High Data");
			array[304] = new EyeStep.OP_INFO("0F+6B", "packssdw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Pack with Signed Saturation");
			array[305] = new EyeStep.OP_INFO("66+0F+6B", "packssdw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Pack with Signed Saturation");
			array[306] = new EyeStep.OP_INFO("66+0F+6C", "punpcklqdq", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Unpack Low Data");
			array[307] = new EyeStep.OP_INFO("66+0F+6D", "punpckhqdq", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Unpack High Data");
			array[308] = new EyeStep.OP_INFO("0F+6E", "movd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.r_m32
			}, "Move Doubleword");
			array[309] = new EyeStep.OP_INFO("66+0F+6E", "movd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.r_m32
			}, "Move Doubleword");
			array[310] = new EyeStep.OP_INFO("0F+6F", "movq", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.mm_m64
			}, "Move Quadword");
			array[311] = new EyeStep.OP_INFO("66+0F+6F", "movdqa", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Move Aligned Double Quadword");
			array[312] = new EyeStep.OP_INFO("F3+0F+6F", "movdqu", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Move Unaligned Double Quadword");
			array[313] = new EyeStep.OP_INFO("0F+70", "pshufw", new OP_TYPES[]
			{
				OP_TYPES.mm_m64,
				OP_TYPES.imm8
			}, "Shuffle Packed Words");
			array[314] = new EyeStep.OP_INFO("F3+0F+70", "pshuflw", new OP_TYPES[]
			{
				OP_TYPES.xmm_m128,
				OP_TYPES.imm8
			}, "Shuffle Packed Low Words");
			array[315] = new EyeStep.OP_INFO("66+0F+70", "pshufhw", new OP_TYPES[]
			{
				OP_TYPES.xmm_m128,
				OP_TYPES.imm8
			}, "Shuffle Packed High Words");
			array[316] = new EyeStep.OP_INFO("F2+0F+70", "pshufd", new OP_TYPES[]
			{
				OP_TYPES.xmm_m128,
				OP_TYPES.imm8
			}, "Shuffle Packed Doublewords");
			array[317] = new EyeStep.OP_INFO("0F+71+m2", "psrlw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.imm8
			}, "Shift Packed Data Right Logical");
			array[318] = new EyeStep.OP_INFO("66+0F+71+m2", "psrlw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.imm8
			}, "Shift Packed Data Right Logical");
			array[319] = new EyeStep.OP_INFO("0F+71+m4", "psraw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.imm8
			}, "Shift Packed Data Right Arithmetic");
			array[320] = new EyeStep.OP_INFO("66+0F+71+m4", "psraw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.imm8
			}, "Shift Packed Data Right Arithmetic");
			array[321] = new EyeStep.OP_INFO("0F+71+m6", "psllw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.imm8
			}, "Shift Packed Data Left Logical");
			array[322] = new EyeStep.OP_INFO("66+0F+71+m6", "psllw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.imm8
			}, "Shift Packed Data Left Logical");
			array[323] = new EyeStep.OP_INFO("0F+72+m2", "psrld", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.imm8
			}, "Shift Double Quadword Right Logical");
			array[324] = new EyeStep.OP_INFO("66+0F+72+m2", "psrld", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.imm8
			}, "Shift Double Quadword Right Logical");
			array[325] = new EyeStep.OP_INFO("0F+72+m4", "psrad", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.imm8
			}, "Shift Packed Data Right Arithmetic");
			array[326] = new EyeStep.OP_INFO("66+0F+72+m4", "psrad", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.imm8
			}, "Shift Packed Data Right Arithmetic");
			array[327] = new EyeStep.OP_INFO("0F+72+m6", "pslld", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.imm8
			}, "Shift Packed Data Left Logical");
			array[328] = new EyeStep.OP_INFO("66+0F+72+m6", "pslld", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.imm8
			}, "Shift Packed Data Left Logical");
			array[329] = new EyeStep.OP_INFO("0F+73+m2", "psrld", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.imm8
			}, "Shift Packed Data Right Logical");
			array[330] = new EyeStep.OP_INFO("66+0F+73+m2", "psrld", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.imm8
			}, "Shift Packed Data Right Logical");
			array[331] = new EyeStep.OP_INFO("0F+73+m3", "psrad", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.imm8
			}, "Shift Double Quadword Right Logical");
			array[332] = new EyeStep.OP_INFO("66+0F+73+m6", "psrad", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.imm8
			}, "Shift Packed Data Left Logical");
			array[333] = new EyeStep.OP_INFO("0F+73+m6", "pslld", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.imm8
			}, "Shift Packed Data Left Logical");
			array[334] = new EyeStep.OP_INFO("66+0F+73+m7", "pslld", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.imm8
			}, "Shift Double Quadword Left Logical");
			array[335] = new EyeStep.OP_INFO("0F+74", "pcmpeqb", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Compare Packed Data for Equal");
			array[336] = new EyeStep.OP_INFO("66+0F+74", "pcmpeqb", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Compare Packed Data for Equal");
			array[337] = new EyeStep.OP_INFO("0F+75", "pcmpeqw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Compare Packed Data for Equal");
			array[338] = new EyeStep.OP_INFO("66+0F+75", "pcmpeqw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Compare Packed Data for Equal");
			array[339] = new EyeStep.OP_INFO("0F+76", "pcmpeqd", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Compare Packed Data for Equal");
			array[340] = new EyeStep.OP_INFO("66+0F+76", "pcmpeqd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Compare Packed Data for Equal");
			array[341] = new EyeStep.OP_INFO("0F+77", "emms", new OP_TYPES[0], "Empty MMX Technology State");
			array[342] = new EyeStep.OP_INFO("0F+78", "vmread", new OP_TYPES[0], "Read Field from Virtual-Machine Control Structure");
			array[343] = new EyeStep.OP_INFO("0F+79", "vmwrite", new OP_TYPES[0], "Write Field to Virtual-Machine Control Structure");
			array[344] = new EyeStep.OP_INFO("66+0F+7C", "haddpd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Packed Double-FP Horizontal Add");
			array[345] = new EyeStep.OP_INFO("F2+0F+7C", "haddps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Packed Single-FP Horizontal Add");
			array[346] = new EyeStep.OP_INFO("66+0F+7D", "hsubpd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Packed Double-FP Horizontal Subtract");
			array[347] = new EyeStep.OP_INFO("F2+0F+7D", "hsubps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Packed Single-FP Horizontal Subtract");
			array[348] = new EyeStep.OP_INFO("0F+7E", "movd", new OP_TYPES[]
			{
				OP_TYPES.r_m32,
				OP_TYPES.mm
			}, "Move Doubleword");
			array[349] = new EyeStep.OP_INFO("66+0F+7E", "movd", new OP_TYPES[]
			{
				OP_TYPES.r_m32,
				OP_TYPES.xmm
			}, "Move Doubleword");
			array[350] = new EyeStep.OP_INFO("F3+0F+7E", "movq", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m64
			}, "Move Quadword");
			array[351] = new EyeStep.OP_INFO("0F+7F", "movq", new OP_TYPES[]
			{
				OP_TYPES.xmm_m64,
				OP_TYPES.mm
			}, "Move Quadword");
			array[352] = new EyeStep.OP_INFO("66+0F+7F", "movdqa", new OP_TYPES[]
			{
				OP_TYPES.xmm_m128,
				OP_TYPES.xmm
			}, "Move Aligned Double Quadword");
			array[353] = new EyeStep.OP_INFO("F3+0F+7F", "movdqu", new OP_TYPES[]
			{
				OP_TYPES.xmm_m128,
				OP_TYPES.xmm
			}, "Move Unaligned Double Quadword");
			array[354] = new EyeStep.OP_INFO("0F+80", "long jo", new OP_TYPES[]
			{
				OP_TYPES.rel16_32
			}, "Jump far if overflow (OF=1)");
			array[355] = new EyeStep.OP_INFO("0F+81", "long jno", new OP_TYPES[]
			{
				OP_TYPES.rel16_32
			}, "Jump far if not overflow (OF=0)");
			array[356] = new EyeStep.OP_INFO("0F+82", "long jb", new OP_TYPES[]
			{
				OP_TYPES.rel16_32
			}, "Jump far if below/not above or equal/carry (CF=1)");
			array[357] = new EyeStep.OP_INFO("0F+83", "long jnb", new OP_TYPES[]
			{
				OP_TYPES.rel16_32
			}, "Jump far if not below/above or equal/not carry (CF=0)");
			array[358] = new EyeStep.OP_INFO("0F+84", "long je", new OP_TYPES[]
			{
				OP_TYPES.rel16_32
			}, "Jump far if zero/equal (ZF=1)");
			array[359] = new EyeStep.OP_INFO("0F+85", "long jne", new OP_TYPES[]
			{
				OP_TYPES.rel16_32
			}, "Jump far if not zero/not equal (ZF=0)");
			array[360] = new EyeStep.OP_INFO("0F+86", "long jna", new OP_TYPES[]
			{
				OP_TYPES.rel16_32
			}, "Jump far if below or equal/not above (CF=1 OR ZF=1)");
			array[361] = new EyeStep.OP_INFO("0F+87", "long ja", new OP_TYPES[]
			{
				OP_TYPES.rel16_32
			}, "Jump far if not below or equal/above (CF=0 AND ZF=0)");
			array[362] = new EyeStep.OP_INFO("0F+88", "long js", new OP_TYPES[]
			{
				OP_TYPES.rel16_32
			}, "Jump far if sign (SF=1)");
			array[363] = new EyeStep.OP_INFO("0F+89", "long jns", new OP_TYPES[]
			{
				OP_TYPES.rel16_32
			}, "Jump far if not sign (SF=0)");
			array[364] = new EyeStep.OP_INFO("0F+8A", "long jp", new OP_TYPES[]
			{
				OP_TYPES.rel16_32
			}, "Jump far if parity/parity even (PF=1)");
			array[365] = new EyeStep.OP_INFO("0F+8B", "long jnp", new OP_TYPES[]
			{
				OP_TYPES.rel16_32
			}, "Jump far if not parity/parity odd (PF=0)");
			array[366] = new EyeStep.OP_INFO("0F+8C", "long jl", new OP_TYPES[]
			{
				OP_TYPES.rel16_32
			}, "Jump far if less/not greater (SF!=OF)");
			array[367] = new EyeStep.OP_INFO("0F+8D", "long jnl", new OP_TYPES[]
			{
				OP_TYPES.rel16_32
			}, "Jump far if not less/greater or equal (SF=OF)");
			array[368] = new EyeStep.OP_INFO("0F+8E", "long jng", new OP_TYPES[]
			{
				OP_TYPES.rel16_32
			}, "Jump far if less or equal/not greater ((ZF=1) OR (SF!=OF))");
			array[369] = new EyeStep.OP_INFO("0F+8F", "long jg", new OP_TYPES[]
			{
				OP_TYPES.rel16_32
			}, "Jump far if not less nor equal/greater ((ZF=0) AND (SF=OF))");
			array[370] = new EyeStep.OP_INFO("0F+90", "seto", new OP_TYPES[]
			{
				OP_TYPES.r_m8
			}, "Set Byte on Condition - overflow (OF=1)");
			array[371] = new EyeStep.OP_INFO("0F+91", "setno", new OP_TYPES[]
			{
				OP_TYPES.r_m8
			}, "Set Byte on Condition - not overflow (OF=0)");
			array[372] = new EyeStep.OP_INFO("0F+92", "setb", new OP_TYPES[]
			{
				OP_TYPES.r_m8
			}, "Set Byte on Condition - below/not above or equal/carry (CF=1)");
			array[373] = new EyeStep.OP_INFO("0F+93", "setnb", new OP_TYPES[]
			{
				OP_TYPES.r_m8
			}, "Set Byte on Condition - not below/above or equal/not carry (CF=0)");
			array[374] = new EyeStep.OP_INFO("0F+94", "sete", new OP_TYPES[]
			{
				OP_TYPES.r_m8
			}, "Set Byte on Condition - zero/equal (ZF=1)");
			array[375] = new EyeStep.OP_INFO("0F+95", "setne", new OP_TYPES[]
			{
				OP_TYPES.r_m8
			}, "Set Byte on Condition - not zero/not equal (ZF=0)");
			array[376] = new EyeStep.OP_INFO("0F+96", "setna", new OP_TYPES[]
			{
				OP_TYPES.r_m8
			}, "Set Byte on Condition - below or equal/not above (CF=1 OR ZF=1)");
			array[377] = new EyeStep.OP_INFO("0F+97", "seta", new OP_TYPES[]
			{
				OP_TYPES.r_m8
			}, "Set Byte on Condition - not below or equal/above (CF=0 AND ZF=0)");
			array[378] = new EyeStep.OP_INFO("0F+98", "sets", new OP_TYPES[]
			{
				OP_TYPES.r_m8
			}, "Set Byte on Condition - sign (SF=1)");
			array[379] = new EyeStep.OP_INFO("0F+99", "setns", new OP_TYPES[]
			{
				OP_TYPES.r_m8
			}, "Set Byte on Condition - not sign (SF=0)");
			array[380] = new EyeStep.OP_INFO("0F+9A", "setp", new OP_TYPES[]
			{
				OP_TYPES.r_m8
			}, "Set Byte on Condition - parity/parity even (PF=1)");
			array[381] = new EyeStep.OP_INFO("0F+9B", "setnp", new OP_TYPES[]
			{
				OP_TYPES.r_m8
			}, "Set Byte on Condition - not parity/parity odd (PF=0)");
			array[382] = new EyeStep.OP_INFO("0F+9C", "setl", new OP_TYPES[]
			{
				OP_TYPES.r_m8
			}, "Set Byte on Condition - less/not greater (SF!=OF)");
			array[383] = new EyeStep.OP_INFO("0F+9D", "setnl", new OP_TYPES[]
			{
				OP_TYPES.r_m8
			}, "Set Byte on Condition - not less/greater or equal (SF=OF)");
			array[384] = new EyeStep.OP_INFO("0F+9E", "setng", new OP_TYPES[]
			{
				OP_TYPES.r_m8
			}, "Set Byte on Condition - less or equal/not greater ((ZF=1) OR (SF!=OF))");
			array[385] = new EyeStep.OP_INFO("0F+9F", "setg", new OP_TYPES[]
			{
				OP_TYPES.r_m8
			}, "Set Byte on Condition - not less nor equal/greater ((ZF=0) AND (SF=OF))");
			array[386] = new EyeStep.OP_INFO("0F+A0", "push", new OP_TYPES[]
			{
				OP_TYPES.FS
			}, "Push Word, Doubleword or Quadword Onto the Stack");
			array[387] = new EyeStep.OP_INFO("0F+A1", "pop", new OP_TYPES[]
			{
				OP_TYPES.FS
			}, "Pop a Value from the Stack");
			array[388] = new EyeStep.OP_INFO("0F+A2", "cpuid", new OP_TYPES[]
			{
				OP_TYPES.IA32_BIOS
			}, "CPU Identification");
			array[389] = new EyeStep.OP_INFO("0F+A3", "bt", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.r16_32
			}, "Bit Test");
			array[390] = new EyeStep.OP_INFO("0F+A4", "shld", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.r16_32,
				OP_TYPES.imm8
			}, "Double Precision Shift Left");
			array[391] = new EyeStep.OP_INFO("0F+A5", "shld", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.r16_32,
				OP_TYPES.CL
			}, "Double Precision Shift Left");
			array[392] = new EyeStep.OP_INFO("0F+A8", "push", new OP_TYPES[]
			{
				OP_TYPES.GS
			}, "Push Word, Doubleword or Quadword Onto the Stack");
			array[393] = new EyeStep.OP_INFO("0F+A9", "pop", new OP_TYPES[]
			{
				OP_TYPES.GS
			}, "Pop a Value from the Stack");
			array[394] = new EyeStep.OP_INFO("0F+AA", "rsm", new OP_TYPES[0], "Resume from System Management Mode");
			array[395] = new EyeStep.OP_INFO("0F+AB", "bts", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.r16_32
			}, "Bit Test and Set");
			array[396] = new EyeStep.OP_INFO("0F+AC", "shrd", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.r16_32,
				OP_TYPES.imm8
			}, "Double Precision Shift Right");
			array[397] = new EyeStep.OP_INFO("0F+AD", "shrd", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.r16_32,
				OP_TYPES.CL
			}, "Double Precision Shift Right");
			array[398] = new EyeStep.OP_INFO("0F+AE+m0", "fxsave", new OP_TYPES[]
			{
				OP_TYPES.m512,
				OP_TYPES.ST,
				OP_TYPES.ST1
			}, "Save x87 FPU, MMX, XMM, and MXCSR State");
			array[399] = new EyeStep.OP_INFO("0F+AE+m1", "fxrstor", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.ST1,
				OP_TYPES.ST2
			}, "Restore x87 FPU, MMX, XMM, and MXCSR State");
			array[400] = new EyeStep.OP_INFO("0F+AE+m2", "ldmxcsr", new OP_TYPES[]
			{
				OP_TYPES.m32
			}, "Load MXCSR Register");
			array[401] = new EyeStep.OP_INFO("0F+AE+m3", "stmxcsr", new OP_TYPES[]
			{
				OP_TYPES.m32
			}, "Store MXCSR Register State");
			array[402] = new EyeStep.OP_INFO("0F+AE+m4", "xsave", new OP_TYPES[]
			{
				OP_TYPES.m,
				OP_TYPES.EDX,
				OP_TYPES.EAX
			}, "Save Processor Extended States");
			array[403] = new EyeStep.OP_INFO("0F+AE+m5", "lfence", new OP_TYPES[0], "Load Fence");
			array[404] = new EyeStep.OP_INFO("0F+AE+m5", "xrstor", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.ST1,
				OP_TYPES.ST2
			}, "Restore Processor Extended States");
			array[405] = new EyeStep.OP_INFO("0F+AE+m6", "mfence", new OP_TYPES[0], "Memory Fence");
			array[406] = new EyeStep.OP_INFO("0F+AE+m7", "sfence", new OP_TYPES[0], "Store Fence");
			array[407] = new EyeStep.OP_INFO("0F+AE+m7", "clflush", new OP_TYPES[]
			{
				OP_TYPES.m8
			}, "Flush Cache Line");
			array[408] = new EyeStep.OP_INFO("0F+AF", "imul", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Signed Multiply");
			array[409] = new EyeStep.OP_INFO("0F+B0", "cmpxchg", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.AL,
				OP_TYPES.r8
			}, "Compare and Exchange");
			array[410] = new EyeStep.OP_INFO("0F+B1", "cmpxchg", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.EAX,
				OP_TYPES.r16_32
			}, "Compare and Exchange");
			array[411] = new EyeStep.OP_INFO("0F+B2", "lss", new OP_TYPES[]
			{
				OP_TYPES.SS,
				OP_TYPES.r16_32,
				OP_TYPES.m16_32_and_16_32
			}, "Load Far Pointer");
			array[412] = new EyeStep.OP_INFO("0F+B3", "btr", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.r16_32
			}, "Bit Test and Reset");
			array[413] = new EyeStep.OP_INFO("0F+B4", "lfs", new OP_TYPES[]
			{
				OP_TYPES.FS,
				OP_TYPES.r_m16_32,
				OP_TYPES.m16_32_and_16_32
			}, "Load Far Pointer");
			array[414] = new EyeStep.OP_INFO("0F+B5", "lgs", new OP_TYPES[]
			{
				OP_TYPES.GS,
				OP_TYPES.r_m16_32,
				OP_TYPES.m16_32_and_16_32
			}, "Load Far Pointer");
			array[415] = new EyeStep.OP_INFO("0F+B6", "movzx", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m8
			}, "Move with Zero-Extend");
			array[416] = new EyeStep.OP_INFO("0F+B7", "movzx", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16
			}, "Move with Zero-Extend");
			array[417] = new EyeStep.OP_INFO("F3+0F+B8", "popcnt", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Bit Population Count");
			array[418] = new EyeStep.OP_INFO("0F+B9", "ud", new OP_TYPES[0], "Undefined Instruction");
			array[419] = new EyeStep.OP_INFO("0F+BA+m4", "bt", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm8
			}, "Bit Test");
			array[420] = new EyeStep.OP_INFO("0F+BA+m5", "bts", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm8
			}, "Bit Test and Set");
			array[421] = new EyeStep.OP_INFO("0F+BA+m6", "btr", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm8
			}, "Bit Test and Reset");
			array[422] = new EyeStep.OP_INFO("0F+BA+m7", "btc", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm8
			}, "Bit Test and Complement");
			array[423] = new EyeStep.OP_INFO("0F+BB", "btc", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.r16_32
			}, "Bit Test and Complement");
			array[424] = new EyeStep.OP_INFO("0F+BC", "bsf", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Bit Scan Forward");
			array[425] = new EyeStep.OP_INFO("0F+BD", "bsr", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Bit Scan Reverse");
			array[426] = new EyeStep.OP_INFO("0F+BE", "movsx", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m8
			}, "Move with Sign-Extension");
			array[427] = new EyeStep.OP_INFO("0F+BF", "movsx", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16
			}, "Move with Sign-Extension");
			array[428] = new EyeStep.OP_INFO("0F+C0", "xadd", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.r8
			}, "Exchange and Add");
			array[429] = new EyeStep.OP_INFO("0F+C1", "xadd", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.r16_32
			}, "Exchange and Add");
			array[430] = new EyeStep.OP_INFO("0F+C2", "cmpps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128,
				OP_TYPES.imm8
			}, "Compare Packed Single-FP Values");
			array[431] = new EyeStep.OP_INFO("F3+0F+C2", "cmpss", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m32,
				OP_TYPES.imm8
			}, "Compare Scalar Single-FP Values");
			array[432] = new EyeStep.OP_INFO("66+0F+C2", "cmppd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128,
				OP_TYPES.imm8
			}, "Compare Packed Double-FP Values");
			array[433] = new EyeStep.OP_INFO("F2+0F+C2", "cmpsd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m64,
				OP_TYPES.imm8
			}, "Compare Scalar Double-FP Values");
			array[434] = new EyeStep.OP_INFO("0F+C3", "movnti", new OP_TYPES[]
			{
				OP_TYPES.m32,
				OP_TYPES.r32
			}, "Store Doubleword Using Non-Temporal Hint");
			array[435] = new EyeStep.OP_INFO("0F+C4", "pinsrw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.m16,
				OP_TYPES.imm8
			}, "Insert Word");
			array[436] = new EyeStep.OP_INFO("66+0F+C4", "pinsrw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.m16,
				OP_TYPES.imm8
			}, "Insert Word");
			array[437] = new EyeStep.OP_INFO("0F+C5", "pextrw", new OP_TYPES[]
			{
				OP_TYPES.r32,
				OP_TYPES.mm,
				OP_TYPES.imm8
			}, "Extract Word");
			array[438] = new EyeStep.OP_INFO("66+0F+C5", "pextrw", new OP_TYPES[]
			{
				OP_TYPES.r32,
				OP_TYPES.xmm,
				OP_TYPES.imm8
			}, "Extract Word");
			array[439] = new EyeStep.OP_INFO("0F+C6", "shufps", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128,
				OP_TYPES.imm8
			}, "Shuffle Packed Single-FP Values");
			array[440] = new EyeStep.OP_INFO("66+0F+C6", "shufpd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128,
				OP_TYPES.imm8
			}, "Shuffle Packed Double-FP Values");
			array[441] = new EyeStep.OP_INFO("0F+C7+m1", "cmpxchg8b", new OP_TYPES[]
			{
				OP_TYPES.m64,
				OP_TYPES.EAX,
				OP_TYPES.EDX
			}, "Compare and Exchange Bytes");
			array[442] = new EyeStep.OP_INFO("0F+C7+m6", "vmptrld", new OP_TYPES[]
			{
				OP_TYPES.m64
			}, "Load Pointer to Virtual-Machine Control Structure");
			array[443] = new EyeStep.OP_INFO("66+0F+C7+m6", "vmclean", new OP_TYPES[]
			{
				OP_TYPES.m64
			}, "Clear Virtual-Machine Control Structure");
			array[444] = new EyeStep.OP_INFO("F3+0F+C7+m6", "vmxon", new OP_TYPES[]
			{
				OP_TYPES.m64
			}, "Enter VMX Operation");
			array[445] = new EyeStep.OP_INFO("0F+C7+m7", "vmptrst", new OP_TYPES[]
			{
				OP_TYPES.m64
			}, "Store Pointer to Virtual-Machine Control Structure");
			array[446] = new EyeStep.OP_INFO("0F+C8+r", "bswap", new OP_TYPES[]
			{
				OP_TYPES.r16_32
			}, "Byte Swap");
			array[447] = new EyeStep.OP_INFO("66+0F+D0", "addsubpd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Packed Double-FP Add/Subtract");
			array[448] = new EyeStep.OP_INFO("F2+0F+D0", "addsubpd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Packed Single-FP Add/Subtract");
			array[449] = new EyeStep.OP_INFO("0F+D1", "psrlw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Shift Packed Data Right Logical");
			array[450] = new EyeStep.OP_INFO("66+0F+D1", "psrlw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Shift Packed Data Right Logical");
			array[451] = new EyeStep.OP_INFO("0F+D2", "psrld", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Shift Packed Data Right Logical");
			array[452] = new EyeStep.OP_INFO("66+0F+D2", "psrld", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Shift Packed Data Right Logical");
			array[453] = new EyeStep.OP_INFO("0F+D3", "psrlq", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Shift Packed Data Right Logical");
			array[454] = new EyeStep.OP_INFO("66+0F+D3", "psrlq", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Shift Packed Data Right Logical");
			array[455] = new EyeStep.OP_INFO("0F+D4", "paddq", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Add Packed Quadword Integers");
			array[456] = new EyeStep.OP_INFO("66+0F+D4", "paddq", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Add Packed Quadword Integers");
			array[457] = new EyeStep.OP_INFO("0F+D5", "pmullw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Multiply Packed Signed Integers and Store Low Result");
			array[458] = new EyeStep.OP_INFO("66+0F+D5", "pmullw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Multiply Packed Signed Integers and Store Low Result");
			array[459] = new EyeStep.OP_INFO("66+0F+D6", "movq", new OP_TYPES[]
			{
				OP_TYPES.xmm_m64,
				OP_TYPES.xmm
			}, "Move Quadword");
			array[460] = new EyeStep.OP_INFO("F3+0F+D6", "movq2dq", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.mm
			}, "Move Quadword from MMX Technology to XMM Register");
			array[461] = new EyeStep.OP_INFO("F2+0F+D6", "movdq2q", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.xmm
			}, "Move Quadword from XMM to MMX Technology Register");
			array[462] = new EyeStep.OP_INFO("0F+D7", "pmovmskb", new OP_TYPES[]
			{
				OP_TYPES.r32,
				OP_TYPES.mm
			}, "Move Byte Mask");
			array[463] = new EyeStep.OP_INFO("66+0F+D7", "pmovmskb", new OP_TYPES[]
			{
				OP_TYPES.r32,
				OP_TYPES.xmm
			}, "Move Byte Mask");
			array[464] = new EyeStep.OP_INFO("0F+D8", "psubusb", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Subtract Packed Unsigned Integers with Unsigned Saturation");
			array[465] = new EyeStep.OP_INFO("66+0F+D8", "psubusb", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Subtract Packed Unsigned Integers with Unsigned Saturation");
			array[466] = new EyeStep.OP_INFO("0F+D9", "psubusw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Subtract Packed Unsigned Integers with Unsigned Saturation");
			array[467] = new EyeStep.OP_INFO("66+0F+D9", "psubusw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Subtract Packed Unsigned Integers with Unsigned Saturation");
			array[468] = new EyeStep.OP_INFO("0F+DA", "pminub", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Minimum of Packed Unsigned Byte Integers");
			array[469] = new EyeStep.OP_INFO("66+0F+DA", "pminub", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Minimum of Packed Unsigned Byte Integers");
			array[470] = new EyeStep.OP_INFO("0F+DB", "pand", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Logical AND");
			array[471] = new EyeStep.OP_INFO("66+0F+DB", "pand", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Logical AND");
			array[472] = new EyeStep.OP_INFO("0F+DC", "paddusb", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Add Packed Unsigned Integers with Unsigned Saturation");
			array[473] = new EyeStep.OP_INFO("66+0F+DC", "paddusb", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Add Packed Unsigned Integers with Unsigned Saturation");
			array[474] = new EyeStep.OP_INFO("0F+DD", "paddusw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Add Packed Unsigned Integers with Unsigned Saturation");
			array[475] = new EyeStep.OP_INFO("66+0F+DD", "paddusw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Add Packed Unsigned Integers with Unsigned Saturation");
			array[476] = new EyeStep.OP_INFO("0F+DE", "pmaxub", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Maximum of Packed Unsigned Byte Integers");
			array[477] = new EyeStep.OP_INFO("66+0F+DE", "pmaxub", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Maximum of Packed Unsigned Byte Integers");
			array[478] = new EyeStep.OP_INFO("0F+DF", "pandn", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Logical AND NOT");
			array[479] = new EyeStep.OP_INFO("66+0F+DF", "pandn", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Logical AND NOT");
			array[480] = new EyeStep.OP_INFO("0F+E0", "pavgb", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Average Packed Integers");
			array[481] = new EyeStep.OP_INFO("66+0F+E0", "pavgb", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Average Packed Integers");
			array[482] = new EyeStep.OP_INFO("0F+E1", "psraw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Shift Packed Data Right Arithmetic");
			array[483] = new EyeStep.OP_INFO("66+0F+E1", "psraw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Shift Packed Data Right Arithmetic");
			array[484] = new EyeStep.OP_INFO("0F+E2", "psrad", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Shift Packed Data Right Arithmetic");
			array[485] = new EyeStep.OP_INFO("66+0F+E2", "psrad", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Shift Packed Data Right Arithmetic");
			array[486] = new EyeStep.OP_INFO("0F+E3", "pavgw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Average Packed Integers");
			array[487] = new EyeStep.OP_INFO("66+0F+E3", "pavgw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Average Packed Integers");
			array[488] = new EyeStep.OP_INFO("0F+E4", "pmulhuw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Multiply Packed Unsigned Integers and Store High Result");
			array[489] = new EyeStep.OP_INFO("66+0F+E4", "pmulhuw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Multiply Packed Unsigned Integers and Store High Result");
			array[490] = new EyeStep.OP_INFO("0F+E5", "pmulhw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Multiply Packed Signed Integers and Store High Result");
			array[491] = new EyeStep.OP_INFO("66+0F+E5", "pmulhw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Multiply Packed Signed Integers and Store High Result");
			array[492] = new EyeStep.OP_INFO("F2+0F+E6", "cvtpd2dq", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Convert Packed Double-FP Values to DW Integers");
			array[493] = new EyeStep.OP_INFO("66+0F+E6", "cvttpd2dq", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Convert with Trunc. Packed Double-FP Values to DW Integers");
			array[494] = new EyeStep.OP_INFO("F3+0F+E6", "cvtdq2pd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Convert Packed DW Integers to Double-FP Values");
			array[495] = new EyeStep.OP_INFO("0F+E7", "movntq", new OP_TYPES[]
			{
				OP_TYPES.m64,
				OP_TYPES.mm
			}, "Store of Quadword Using Non-Temporal Hint");
			array[496] = new EyeStep.OP_INFO("66+0F+E7", "movntdq", new OP_TYPES[]
			{
				OP_TYPES.m128,
				OP_TYPES.xmm
			}, "Store Double Quadword Using Non-Temporal Hint");
			array[497] = new EyeStep.OP_INFO("0F+E8", "psubsb", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Subtract Packed Signed Integers with Signed Saturation");
			array[498] = new EyeStep.OP_INFO("66+0F+E8", "psubsb", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Subtract Packed Signed Integers with Signed Saturation");
			array[499] = new EyeStep.OP_INFO("0F+E9", "psubsw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Subtract Packed Signed Integers with Signed Saturation");
			array[500] = new EyeStep.OP_INFO("66+0F+E9", "psubsw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Subtract Packed Signed Integers with Signed Saturation");
			array[501] = new EyeStep.OP_INFO("0F+EA", "pminsw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Minimum of Packed Signed Word Integers");
			array[502] = new EyeStep.OP_INFO("66+0F+EA", "pminsw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Minimum of Packed Signed Word Integers");
			array[503] = new EyeStep.OP_INFO("0F+EB", "por", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Bitwise Logical OR");
			array[504] = new EyeStep.OP_INFO("66+0F+EB", "por", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Bitwise Logical OR");
			array[505] = new EyeStep.OP_INFO("0F+EC", "paddsb", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Add Packed Signed Integers with Signed Saturation");
			array[506] = new EyeStep.OP_INFO("66+0F+EC", "paddsb", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Add Packed Signed Integers with Signed Saturation");
			array[507] = new EyeStep.OP_INFO("0F+ED", "paddsw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Add Packed Signed Integers with Signed Saturation");
			array[508] = new EyeStep.OP_INFO("66+0F+ED", "paddsw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Add Packed Signed Integers with Signed Saturation");
			array[509] = new EyeStep.OP_INFO("0F+EE", "pmaxsw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Maximum of Packed Signed Word Integers");
			array[510] = new EyeStep.OP_INFO("66+0F+EE", "pmaxsw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Maximum of Packed Signed Word Integers");
			array[511] = new EyeStep.OP_INFO("0F+EF", "pxor", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Logical Exclusive OR");
			array[512] = new EyeStep.OP_INFO("66+0F+EF", "pxor", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Logical Exclusive OR");
			array[513] = new EyeStep.OP_INFO("F2+0F+F0", "lddqu", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.m128
			}, "Load Unaligned Integer 128 Bits");
			array[514] = new EyeStep.OP_INFO("0F+F1", "psllw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Shift Packed Data Left Logical");
			array[515] = new EyeStep.OP_INFO("66+0F+F1", "psllw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Shift Packed Data Left Logical");
			array[516] = new EyeStep.OP_INFO("0F+F2", "pslld", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Shift Packed Data Left Logical");
			array[517] = new EyeStep.OP_INFO("66+0F+F2", "pslld", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Shift Packed Data Left Logical");
			array[518] = new EyeStep.OP_INFO("0F+F3", "psllq", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Shift Packed Data Left Logical");
			array[519] = new EyeStep.OP_INFO("66+0F+F3", "psllq", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Shift Packed Data Left Logical");
			array[520] = new EyeStep.OP_INFO("0F+F4", "pmuludq", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Multiply Packed Unsigned DW Integers");
			array[521] = new EyeStep.OP_INFO("66+0F+F4", "pmuludq", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Multiply Packed Unsigned DW Integers");
			array[522] = new EyeStep.OP_INFO("0F+F5", "pmaddwd", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Multiply and Add Packed Integers");
			array[523] = new EyeStep.OP_INFO("66+0F+F5", "pmaddwd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Multiply and Add Packed Integers");
			array[524] = new EyeStep.OP_INFO("0F+F6", "psadbw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Compute Sum of Absolute Differences");
			array[525] = new EyeStep.OP_INFO("66+0F+F6", "psadbw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Compute Sum of Absolute Differences");
			array[526] = new EyeStep.OP_INFO("0F+F7", "maskmovq", new OP_TYPES[]
			{
				OP_TYPES.m64,
				OP_TYPES.mm,
				OP_TYPES.mm
			}, "Store Selected Bytes of Quadword");
			array[527] = new EyeStep.OP_INFO("66+0F+F7", "maskmovdqu", new OP_TYPES[]
			{
				OP_TYPES.m128,
				OP_TYPES.xmm,
				OP_TYPES.xmm
			}, "Store Selected Bytes of Double Quadword");
			array[528] = new EyeStep.OP_INFO("0F+F8", "psubb", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Subtract Packed Integers");
			array[529] = new EyeStep.OP_INFO("66+0F+F8", "psubb", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Subtract Packed Integers");
			array[530] = new EyeStep.OP_INFO("0F+F9", "psubw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Subtract Packed Integers");
			array[531] = new EyeStep.OP_INFO("66+0F+F9", "psubw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Subtract Packed Integers");
			array[532] = new EyeStep.OP_INFO("0F+FA", "psubd", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Subtract Packed Integers");
			array[533] = new EyeStep.OP_INFO("66+0F+FA", "psubd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Subtract Packed Integers");
			array[534] = new EyeStep.OP_INFO("0F+FB", "psubq", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Subtract Packed Quadword Integers");
			array[535] = new EyeStep.OP_INFO("66+0F+FB", "psubq", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Subtract Packed Quadword Integers");
			array[536] = new EyeStep.OP_INFO("0F+FC", "paddb", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Add Packed Integers");
			array[537] = new EyeStep.OP_INFO("66+0F+FC", "paddb", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Add Packed Integers");
			array[538] = new EyeStep.OP_INFO("0F+FD", "paddw", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Add Packed Integers");
			array[539] = new EyeStep.OP_INFO("66+0F+FD", "paddw", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Add Packed Integers");
			array[540] = new EyeStep.OP_INFO("0F+FE", "paddd", new OP_TYPES[]
			{
				OP_TYPES.mm,
				OP_TYPES.mm_m64
			}, "Add Packed Integers");
			array[541] = new EyeStep.OP_INFO("66+0F+FE", "paddd", new OP_TYPES[]
			{
				OP_TYPES.xmm,
				OP_TYPES.xmm_m128
			}, "Add Packed Integers");
			array[542] = new EyeStep.OP_INFO("10", "adc", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.r8
			}, "Add with Carry");
			array[543] = new EyeStep.OP_INFO("11", "adc", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.r16_32
			}, "Add with Carry");
			array[544] = new EyeStep.OP_INFO("12", "adc", new OP_TYPES[]
			{
				OP_TYPES.r8,
				OP_TYPES.r_m8
			}, "Add with Carry");
			array[545] = new EyeStep.OP_INFO("13", "adc", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Add with Carry");
			array[546] = new EyeStep.OP_INFO("14", "adc", new OP_TYPES[]
			{
				OP_TYPES.AL,
				OP_TYPES.imm8
			}, "Add with Carry");
			array[547] = new EyeStep.OP_INFO("15", "adc", new OP_TYPES[]
			{
				OP_TYPES.EAX,
				OP_TYPES.imm16_32
			}, "Add with Carry");
			array[548] = new EyeStep.OP_INFO("16", "push", new OP_TYPES[]
			{
				OP_TYPES.SS
			}, "Push Stack Segment onto the stack");
			array[549] = new EyeStep.OP_INFO("17", "pop", new OP_TYPES[]
			{
				OP_TYPES.SS
			}, "Pop Stack Segment off of the stack");
			array[550] = new EyeStep.OP_INFO("18", "sbb", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.r8
			}, "Integer Subtraction with Borrow");
			array[551] = new EyeStep.OP_INFO("19", "sbb", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.r16_32
			}, "Integer Subtraction with Borrow");
			array[552] = new EyeStep.OP_INFO("1A", "sbb", new OP_TYPES[]
			{
				OP_TYPES.r8,
				OP_TYPES.r_m8
			}, "Integer Subtraction with Borrow");
			array[553] = new EyeStep.OP_INFO("1B", "sbb", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Integer Subtraction with Borrow");
			array[554] = new EyeStep.OP_INFO("1C", "sbb", new OP_TYPES[]
			{
				OP_TYPES.AL,
				OP_TYPES.imm8
			}, "Integer Subtraction with Borrow");
			array[555] = new EyeStep.OP_INFO("1D", "sbb", new OP_TYPES[]
			{
				OP_TYPES.EAX,
				OP_TYPES.imm16_32
			}, "Integer Subtraction with Borrow");
			array[556] = new EyeStep.OP_INFO("1E", "push", new OP_TYPES[]
			{
				OP_TYPES.DS
			}, "Push Data Segment onto the stack");
			array[557] = new EyeStep.OP_INFO("1F", "pop", new OP_TYPES[]
			{
				OP_TYPES.DS
			}, "Pop Data Segment off of the stack");
			array[558] = new EyeStep.OP_INFO("20", "and", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.r8
			}, "Logical AND");
			array[559] = new EyeStep.OP_INFO("21", "and", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.r16_32
			}, "Logical AND");
			array[560] = new EyeStep.OP_INFO("22", "and", new OP_TYPES[]
			{
				OP_TYPES.r8,
				OP_TYPES.r_m8
			}, "Logical AND");
			array[561] = new EyeStep.OP_INFO("23", "and", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Logical AND");
			array[562] = new EyeStep.OP_INFO("24", "and", new OP_TYPES[]
			{
				OP_TYPES.AL,
				OP_TYPES.imm8
			}, "Logical AND");
			array[563] = new EyeStep.OP_INFO("25", "and", new OP_TYPES[]
			{
				OP_TYPES.EAX,
				OP_TYPES.imm16_32
			}, "Logical AND");
			array[564] = new EyeStep.OP_INFO("27", "daa", new OP_TYPES[1], "Decimal Adjust AL after Addition");
			array[565] = new EyeStep.OP_INFO("28", "sub", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.r8
			}, "Subtract");
			array[566] = new EyeStep.OP_INFO("29", "sub", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.r16_32
			}, "Subtract");
			array[567] = new EyeStep.OP_INFO("2A", "sub", new OP_TYPES[]
			{
				OP_TYPES.r8,
				OP_TYPES.r_m8
			}, "Subtract");
			array[568] = new EyeStep.OP_INFO("2B", "sub", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Subtract");
			array[569] = new EyeStep.OP_INFO("2C", "sub", new OP_TYPES[]
			{
				OP_TYPES.AL,
				OP_TYPES.imm8
			}, "Subtract");
			array[570] = new EyeStep.OP_INFO("2D", "sub", new OP_TYPES[]
			{
				OP_TYPES.EAX,
				OP_TYPES.imm16_32
			}, "Subtract");
			array[571] = new EyeStep.OP_INFO("2F", "das", new OP_TYPES[1], "Decimal Adjust AL after Subtraction");
			array[572] = new EyeStep.OP_INFO("30", "xor", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.r8
			}, "Logical Exclusive OR");
			array[573] = new EyeStep.OP_INFO("31", "xor", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.r16_32
			}, "Logical Exclusive OR");
			array[574] = new EyeStep.OP_INFO("32", "xor", new OP_TYPES[]
			{
				OP_TYPES.r8,
				OP_TYPES.r_m8
			}, "Logical Exclusive OR");
			array[575] = new EyeStep.OP_INFO("33", "xor", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Logical Exclusive OR");
			array[576] = new EyeStep.OP_INFO("34", "xor", new OP_TYPES[]
			{
				OP_TYPES.AL,
				OP_TYPES.imm8
			}, "Logical Exclusive OR");
			array[577] = new EyeStep.OP_INFO("35", "xor", new OP_TYPES[]
			{
				OP_TYPES.EAX,
				OP_TYPES.imm16_32
			}, "Logical Exclusive OR");
			array[578] = new EyeStep.OP_INFO("37", "aaa", new OP_TYPES[]
			{
				OP_TYPES.AL,
				OP_TYPES.AH
			}, "ASCII Adjust After Addition");
			array[579] = new EyeStep.OP_INFO("38", "cmp", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.r8
			}, "Compare Two Operands");
			array[580] = new EyeStep.OP_INFO("39", "cmp", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.r16_32
			}, "Compare Two Operands");
			array[581] = new EyeStep.OP_INFO("3A", "cmp", new OP_TYPES[]
			{
				OP_TYPES.r8,
				OP_TYPES.r_m8
			}, "Compare Two Operands");
			array[582] = new EyeStep.OP_INFO("3B", "cmp", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Compare Two Operands");
			array[583] = new EyeStep.OP_INFO("3C", "cmp", new OP_TYPES[]
			{
				OP_TYPES.AL,
				OP_TYPES.imm8
			}, "Compare Two Operands");
			array[584] = new EyeStep.OP_INFO("3D", "cmp", new OP_TYPES[]
			{
				OP_TYPES.EAX,
				OP_TYPES.imm16_32
			}, "Compare Two Operands");
			array[585] = new EyeStep.OP_INFO("3F", "aas", new OP_TYPES[]
			{
				OP_TYPES.AL,
				OP_TYPES.AH
			}, "ASCII Adjust AL After Subtraction");
			array[586] = new EyeStep.OP_INFO("40+r", "inc", new OP_TYPES[]
			{
				OP_TYPES.r16_32
			}, "Increment by 1");
			array[587] = new EyeStep.OP_INFO("48+r", "dec", new OP_TYPES[]
			{
				OP_TYPES.r16_32
			}, "Decrement by 1");
			array[588] = new EyeStep.OP_INFO("50+r", "push", new OP_TYPES[]
			{
				OP_TYPES.r16_32
			}, "Push Word, Doubleword or Quadword Onto the Stack");
			array[589] = new EyeStep.OP_INFO("58+r", "pop", new OP_TYPES[]
			{
				OP_TYPES.r16_32
			}, "Pop a Value from the Stack");
			array[590] = new EyeStep.OP_INFO("60", "pushad", new OP_TYPES[0], "Push All General-Purpose Registers");
			array[591] = new EyeStep.OP_INFO("61", "popad", new OP_TYPES[0], "Pop All General-Purpose Registers");
			array[592] = new EyeStep.OP_INFO("62", "bound", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.m16_32_and_16_32
			}, "Check Array Index Against Bounds");
			array[593] = new EyeStep.OP_INFO("63", "arpl", new OP_TYPES[]
			{
				OP_TYPES.r_m16,
				OP_TYPES.r16
			}, "Adjust RPL Field of Segment Selector");
			array[594] = new EyeStep.OP_INFO("63", "arpl", new OP_TYPES[]
			{
				OP_TYPES.r_m16,
				OP_TYPES.r16
			}, "Adjust RPL Field of Segment Selector");
			array[595] = new EyeStep.OP_INFO("68", "push", new OP_TYPES[]
			{
				OP_TYPES.imm16_32
			}, "Push Word, Doubleword or Quadword Onto the Stack");
			array[596] = new EyeStep.OP_INFO("69", "imul", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32,
				OP_TYPES.imm16_32
			}, "Signed Multiply");
			array[597] = new EyeStep.OP_INFO("6A", "push", new OP_TYPES[]
			{
				OP_TYPES.imm8
			}, "Push Word, Doubleword or Quadword Onto the Stack");
			array[598] = new EyeStep.OP_INFO("6B", "imul", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32,
				OP_TYPES.imm8
			}, "Signed Multiply");
			array[599] = new EyeStep.OP_INFO("6C", "insb", new OP_TYPES[0], "Input from Port to String");
			array[600] = new EyeStep.OP_INFO("6D", "insd", new OP_TYPES[0], "Input from Port to String");
			array[601] = new EyeStep.OP_INFO("6E", "outsb", new OP_TYPES[0], "Output String to Port");
			array[602] = new EyeStep.OP_INFO("6F", "outsd", new OP_TYPES[0], "Output String to Port");
			array[603] = new EyeStep.OP_INFO("70", "jo short", new OP_TYPES[]
			{
				OP_TYPES.rel8
			}, "Jump short if overflow (OF=1)");
			array[604] = new EyeStep.OP_INFO("71", "jno short", new OP_TYPES[]
			{
				OP_TYPES.rel8
			}, "Jump short if not overflow (OF=0))");
			array[605] = new EyeStep.OP_INFO("72", "jb short", new OP_TYPES[]
			{
				OP_TYPES.rel8
			}, "Jump short if below/not above or equal/carry (CF=1)");
			array[606] = new EyeStep.OP_INFO("73", "jae short", new OP_TYPES[]
			{
				OP_TYPES.rel8
			}, "Jump short if not below/above or equal/not carry (CF=0))");
			array[607] = new EyeStep.OP_INFO("74", "je short", new OP_TYPES[]
			{
				OP_TYPES.rel8
			}, "Jump short if zero/equal (ZF=1)");
			array[608] = new EyeStep.OP_INFO("75", "jne short", new OP_TYPES[]
			{
				OP_TYPES.rel8
			}, "Jump short if not zero/not equal (ZF=0)");
			array[609] = new EyeStep.OP_INFO("76", "jna short", new OP_TYPES[]
			{
				OP_TYPES.rel8
			}, "Jump short if below or equal/not above (CF=1 OR ZF=1)");
			array[610] = new EyeStep.OP_INFO("77", "ja short", new OP_TYPES[]
			{
				OP_TYPES.rel8
			}, "Jump short if not below or equal/above (CF=0 AND ZF=0)");
			array[611] = new EyeStep.OP_INFO("78", "js short", new OP_TYPES[]
			{
				OP_TYPES.rel8
			}, "Jump short if sign (SF=1)");
			array[612] = new EyeStep.OP_INFO("79", "jns short", new OP_TYPES[]
			{
				OP_TYPES.rel8
			}, "Jump short if not sign (SF=0)");
			array[613] = new EyeStep.OP_INFO("7A", "jp short", new OP_TYPES[]
			{
				OP_TYPES.rel8
			}, "Jump short if parity/parity even (PF=1)");
			array[614] = new EyeStep.OP_INFO("7B", "jnp short", new OP_TYPES[]
			{
				OP_TYPES.rel8
			}, "Jump short if not parity/parity odd (PF=0)");
			array[615] = new EyeStep.OP_INFO("7C", "jl short", new OP_TYPES[]
			{
				OP_TYPES.rel8
			}, "Jump short if less/not greater (SF!=OF)");
			array[616] = new EyeStep.OP_INFO("7D", "jge short", new OP_TYPES[]
			{
				OP_TYPES.rel8
			}, "Jump short if not less/greater or equal (SF=OF)");
			array[617] = new EyeStep.OP_INFO("7E", "jle short", new OP_TYPES[]
			{
				OP_TYPES.rel8
			}, "Jump short if less or equal/not greater ((ZF=1) OR (SF!=OF))");
			array[618] = new EyeStep.OP_INFO("7F", "jg short", new OP_TYPES[]
			{
				OP_TYPES.rel8
			}, "Jump short if not less nor equal/greater ((ZF=0) AND (SF=OF))");
			array[619] = new EyeStep.OP_INFO("80+m0", "add", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.imm8
			}, "Add");
			array[620] = new EyeStep.OP_INFO("80+m1", "or", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.imm8
			}, "Logical Inclusive OR");
			array[621] = new EyeStep.OP_INFO("80+m2", "adc", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.imm8
			}, "Add with Carry");
			array[622] = new EyeStep.OP_INFO("80+m3", "sbb", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.imm8
			}, "Integer Subtraction with Borrow");
			array[623] = new EyeStep.OP_INFO("80+m4", "and", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.imm8
			}, "Logical AND");
			array[624] = new EyeStep.OP_INFO("80+m5", "sub", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.imm8
			}, "Subtract");
			array[625] = new EyeStep.OP_INFO("80+m6", "xor", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.imm8
			}, "Logical Exclusive OR");
			array[626] = new EyeStep.OP_INFO("80+m7", "cmp", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.imm8
			}, "Compare Two Operands");
			array[627] = new EyeStep.OP_INFO("81+m0", "add", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm16_32
			}, "Add");
			array[628] = new EyeStep.OP_INFO("81+m1", "or", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm16_32
			}, "Logical Inclusive OR");
			array[629] = new EyeStep.OP_INFO("81+m2", "adc", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm16_32
			}, "Add with Carry");
			array[630] = new EyeStep.OP_INFO("81+m3", "sbb", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm16_32
			}, "Integer Subtraction with Borrow");
			array[631] = new EyeStep.OP_INFO("81+m4", "and", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm16_32
			}, "Logical AND");
			array[632] = new EyeStep.OP_INFO("81+m5", "sub", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm16_32
			}, "Subtract");
			array[633] = new EyeStep.OP_INFO("81+m6", "xor", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm16_32
			}, "Logical Exclusive OR");
			array[634] = new EyeStep.OP_INFO("81+m7", "cmp", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm16_32
			}, "Compare Two Operands");
			array[635] = new EyeStep.OP_INFO("82+m0", "add", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.imm8
			}, "Add");
			array[636] = new EyeStep.OP_INFO("82+m1", "or", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.imm8
			}, "Logical Inclusive OR");
			array[637] = new EyeStep.OP_INFO("82+m2", "adc", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.imm8
			}, "Add with Carry");
			array[638] = new EyeStep.OP_INFO("82+m3", "sbb", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.imm8
			}, "Integer Subtraction with Borrow");
			array[639] = new EyeStep.OP_INFO("82+m4", "and", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.imm8
			}, "Logical AND");
			array[640] = new EyeStep.OP_INFO("82+m5", "sub", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.imm8
			}, "Subtract");
			array[641] = new EyeStep.OP_INFO("82+m6", "xor", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.imm8
			}, "Logical Exclusive OR");
			array[642] = new EyeStep.OP_INFO("82+m7", "cmp", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.imm8
			}, "Compare Two Operands");
			array[643] = new EyeStep.OP_INFO("83+m0", "add", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm8
			}, "Add");
			array[644] = new EyeStep.OP_INFO("83+m1", "or", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm8
			}, "Logical Inclusive OR");
			array[645] = new EyeStep.OP_INFO("83+m2", "adc", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm8
			}, "Add with Carry");
			array[646] = new EyeStep.OP_INFO("83+m3", "sbb", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm8
			}, "Integer Subtraction with Borrow");
			array[647] = new EyeStep.OP_INFO("83+m4", "and", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm8
			}, "Logical AND");
			array[648] = new EyeStep.OP_INFO("83+m5", "sub", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm8
			}, "Subtract");
			array[649] = new EyeStep.OP_INFO("83+m6", "xor", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm8
			}, "Logical Exclusive OR");
			array[650] = new EyeStep.OP_INFO("83+m7", "cmp", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm8
			}, "Compare Two Operands");
			array[651] = new EyeStep.OP_INFO("84", "test", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.r8
			}, "Logical Compare");
			array[652] = new EyeStep.OP_INFO("85", "test", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.r16_32
			}, "Logical Compare");
			array[653] = new EyeStep.OP_INFO("86", "xchg", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.r8
			}, "Exchange Register/Memory with Register");
			array[654] = new EyeStep.OP_INFO("87", "xchg", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.r16_32
			}, "Exchange Register/Memory with Register");
			array[655] = new EyeStep.OP_INFO("88", "mov", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.r8
			}, "Move");
			array[656] = new EyeStep.OP_INFO("89", "mov", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.r16_32
			}, "Move");
			array[657] = new EyeStep.OP_INFO("8A", "mov", new OP_TYPES[]
			{
				OP_TYPES.r8,
				OP_TYPES.r_m8
			}, "Move");
			array[658] = new EyeStep.OP_INFO("8B", "mov", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.r_m16_32
			}, "Move");
			array[659] = new EyeStep.OP_INFO("8C", "mov", new OP_TYPES[]
			{
				OP_TYPES.m16,
				OP_TYPES.Sreg
			}, "Move");
			array[660] = new EyeStep.OP_INFO("8D", "lea", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.m32
			}, "Load Effective Address");
			array[661] = new EyeStep.OP_INFO("8E", "mov", new OP_TYPES[]
			{
				OP_TYPES.Sreg,
				OP_TYPES.r_m16
			}, "Move");
			array[662] = new EyeStep.OP_INFO("8F", "pop", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Pop a Value from the Stack");
			array[663] = new EyeStep.OP_INFO("90", "nop", new OP_TYPES[0], "No Operation");
			array[664] = new EyeStep.OP_INFO("90+r", "xchg", new OP_TYPES[]
			{
				OP_TYPES.EAX,
				OP_TYPES.r16_32
			}, "Exchange Register/Memory with Register");
			int num = 665;
			string a = "98";
			string b = "cbw";
			OP_TYPES[] array2 = new OP_TYPES[2];
			array2[0] = OP_TYPES.AX;
			array[num] = new EyeStep.OP_INFO(a, b, array2, "Convert Byte to Word");
			int num2 = 666;
			string a2 = "99";
			string b2 = "cwd";
			OP_TYPES[] array3 = new OP_TYPES[2];
			array3[0] = OP_TYPES.AX;
			array[num2] = new EyeStep.OP_INFO(a2, b2, array3, "Convert Doubleword to Quadword");
			array[667] = new EyeStep.OP_INFO("9A", "callf", new OP_TYPES[]
			{
				OP_TYPES.ptr16_32
			}, "Call Procedure");
			array[668] = new EyeStep.OP_INFO("9B", "fwait", new OP_TYPES[0], "Check pending unmasked floating-point exceptions");
			array[669] = new EyeStep.OP_INFO("9C", "pushfd", new OP_TYPES[0], "Push EFLAGS Register onto the Stack");
			array[670] = new EyeStep.OP_INFO("9D", "popfd", new OP_TYPES[0], "Pop Stack into EFLAGS Register");
			array[671] = new EyeStep.OP_INFO("9E", "sahf", new OP_TYPES[]
			{
				OP_TYPES.AH
			}, "Store AH into Flags");
			array[672] = new EyeStep.OP_INFO("9F", "lahf", new OP_TYPES[]
			{
				OP_TYPES.AH
			}, "Load Status Flags into AH Register");
			array[673] = new EyeStep.OP_INFO("A0", "mov", new OP_TYPES[]
			{
				OP_TYPES.AL,
				OP_TYPES.moffs8
			}, "Move");
			array[674] = new EyeStep.OP_INFO("A1", "mov", new OP_TYPES[]
			{
				OP_TYPES.EAX,
				OP_TYPES.moffs16_32
			}, "Move");
			int num3 = 675;
			string a3 = "A2";
			string b3 = "mov";
			OP_TYPES[] array4 = new OP_TYPES[2];
			array4[0] = OP_TYPES.moffs8;
			array[num3] = new EyeStep.OP_INFO(a3, b3, array4, "Move");
			array[676] = new EyeStep.OP_INFO("A3", "mov", new OP_TYPES[]
			{
				OP_TYPES.moffs16_32,
				OP_TYPES.EAX
			}, "Move");
			array[677] = new EyeStep.OP_INFO("A4", "movsb", new OP_TYPES[0], "Move Data from String to String");
			array[678] = new EyeStep.OP_INFO("A5", "movsw", new OP_TYPES[0], "Move Data from String to String");
			array[679] = new EyeStep.OP_INFO("A6", "cmpsb", new OP_TYPES[0], "Compare String Operands");
			array[680] = new EyeStep.OP_INFO("A7", "cmpsw", new OP_TYPES[0], "Compare String Operands");
			array[681] = new EyeStep.OP_INFO("A8", "test", new OP_TYPES[]
			{
				OP_TYPES.AL,
				OP_TYPES.imm8
			}, "Logical Compare");
			array[682] = new EyeStep.OP_INFO("A9", "test", new OP_TYPES[]
			{
				OP_TYPES.EAX,
				OP_TYPES.imm16_32
			}, "Logical Compare");
			array[683] = new EyeStep.OP_INFO("AA", "stosb", new OP_TYPES[0], "Store String");
			array[684] = new EyeStep.OP_INFO("AB", "stosw", new OP_TYPES[0], "Store String");
			array[685] = new EyeStep.OP_INFO("AC", "lodsb", new OP_TYPES[0], "Load String");
			array[686] = new EyeStep.OP_INFO("AD", "lodsw", new OP_TYPES[0], "Load String");
			array[687] = new EyeStep.OP_INFO("AE", "scasb", new OP_TYPES[0], "Scan String");
			array[688] = new EyeStep.OP_INFO("AF", "scasw", new OP_TYPES[0], "Scan String");
			array[689] = new EyeStep.OP_INFO("B0+r", "mov", new OP_TYPES[]
			{
				OP_TYPES.r8,
				OP_TYPES.imm8
			}, "Move");
			array[690] = new EyeStep.OP_INFO("B8+r", "mov", new OP_TYPES[]
			{
				OP_TYPES.r16_32,
				OP_TYPES.imm16_32
			}, "Move");
			array[691] = new EyeStep.OP_INFO("C0+m0", "rol", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.imm8
			}, "Rotate");
			array[692] = new EyeStep.OP_INFO("C0+m1", "ror", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.imm8
			}, "Rotate");
			array[693] = new EyeStep.OP_INFO("C0+m2", "rcl", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.imm8
			}, "Rotate");
			array[694] = new EyeStep.OP_INFO("C0+m3", "rcr", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.imm8
			}, "Rotate");
			array[695] = new EyeStep.OP_INFO("C0+m4", "shl", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.imm8
			}, "Shift");
			array[696] = new EyeStep.OP_INFO("C0+m5", "shr", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.imm8
			}, "Shift");
			array[697] = new EyeStep.OP_INFO("C0+m6", "sal", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.imm8
			}, "Shift");
			array[698] = new EyeStep.OP_INFO("C0+m7", "sar", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.imm8
			}, "Shift");
			array[699] = new EyeStep.OP_INFO("C1+m0", "rol", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm8
			}, "Rotate");
			array[700] = new EyeStep.OP_INFO("C1+m1", "ror", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm8
			}, "Rotate");
			array[701] = new EyeStep.OP_INFO("C1+m2", "rcl", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm8
			}, "Rotate");
			array[702] = new EyeStep.OP_INFO("C1+m3", "rcr", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm8
			}, "Rotate");
			array[703] = new EyeStep.OP_INFO("C1+m4", "shl", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm8
			}, "Shift");
			array[704] = new EyeStep.OP_INFO("C1+m5", "shr", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm8
			}, "Shift");
			array[705] = new EyeStep.OP_INFO("C1+m6", "sal", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm8
			}, "Shift");
			array[706] = new EyeStep.OP_INFO("C1+m7", "sar", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm8
			}, "Shift");
			array[707] = new EyeStep.OP_INFO("C2", "ret", new OP_TYPES[]
			{
				OP_TYPES.imm16
			}, "Return from procedure");
			array[708] = new EyeStep.OP_INFO("C3", "retn", new OP_TYPES[0], "Return from procedure");
			array[709] = new EyeStep.OP_INFO("C4", "les", new OP_TYPES[]
			{
				OP_TYPES.ES,
				OP_TYPES.r16_32,
				OP_TYPES.m16_32_and_16_32
			}, "Load Far Pointer");
			array[710] = new EyeStep.OP_INFO("C5", "lds", new OP_TYPES[]
			{
				OP_TYPES.DS,
				OP_TYPES.r16_32,
				OP_TYPES.m16_32_and_16_32
			}, "Load Far Pointer");
			array[711] = new EyeStep.OP_INFO("C6", "mov", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.imm8
			}, "Move");
			array[712] = new EyeStep.OP_INFO("C7", "mov", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm16_32
			}, "Move");
			array[713] = new EyeStep.OP_INFO("66+C7", "mov", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm16
			}, "Move");
			array[714] = new EyeStep.OP_INFO("C8", "enter", new OP_TYPES[]
			{
				OP_TYPES.EBP,
				OP_TYPES.imm16,
				OP_TYPES.imm8
			}, "Make Stack Frame for Procedure Parameters");
			array[715] = new EyeStep.OP_INFO("C9", "leave", new OP_TYPES[]
			{
				OP_TYPES.EBP
			}, "High Level Procedure Exit");
			array[716] = new EyeStep.OP_INFO("CA", "retf", new OP_TYPES[]
			{
				OP_TYPES.imm16
			}, "Return from procedure");
			array[717] = new EyeStep.OP_INFO("CB", "retf", new OP_TYPES[0], "Return from procedure");
			array[718] = new EyeStep.OP_INFO("CC", "int 3", new OP_TYPES[0], "Call to Interrupt Procedure");
			array[719] = new EyeStep.OP_INFO("CD", "int", new OP_TYPES[]
			{
				OP_TYPES.imm8
			}, "Call to Interrupt Procedure");
			array[720] = new EyeStep.OP_INFO("CE", "into", new OP_TYPES[0], "Call to Interrupt Procedure");
			array[721] = new EyeStep.OP_INFO("CF", "iretd", new OP_TYPES[0], "Interrupt Return");
			array[722] = new EyeStep.OP_INFO("D0+m0", "rol", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.one
			}, "Rotate");
			array[723] = new EyeStep.OP_INFO("D0+m1", "ror", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.one
			}, "Rotate");
			array[724] = new EyeStep.OP_INFO("D0+m2", "rcl", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.one
			}, "Rotate");
			array[725] = new EyeStep.OP_INFO("D0+m3", "rcr", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.one
			}, "Rotate");
			array[726] = new EyeStep.OP_INFO("D0+m4", "shl", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.one
			}, "Shift");
			array[727] = new EyeStep.OP_INFO("D0+m5", "shr", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.one
			}, "Shift");
			array[728] = new EyeStep.OP_INFO("D0+m6", "shl", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.one
			}, "Shift");
			array[729] = new EyeStep.OP_INFO("D0+m7", "shr", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.one
			}, "Shift");
			array[730] = new EyeStep.OP_INFO("D1+m0", "rol", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.one
			}, "Rotate");
			array[731] = new EyeStep.OP_INFO("D1+m1", "ror", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.one
			}, "Rotate");
			array[732] = new EyeStep.OP_INFO("D1+m2", "rcl", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.one
			}, "Rotate");
			array[733] = new EyeStep.OP_INFO("D1+m3", "rcr", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.one
			}, "Rotate");
			array[734] = new EyeStep.OP_INFO("D1+m4", "shl", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.one
			}, "Shift");
			array[735] = new EyeStep.OP_INFO("D1+m5", "shr", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.one
			}, "Shift");
			array[736] = new EyeStep.OP_INFO("D1+m6", "shl", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.one
			}, "Shift");
			array[737] = new EyeStep.OP_INFO("D1+m7", "shr", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.one
			}, "Shift");
			array[738] = new EyeStep.OP_INFO("D2+m0", "rol", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.CL
			}, "Rotate");
			array[739] = new EyeStep.OP_INFO("D2+m1", "ror", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.CL
			}, "Rotate");
			array[740] = new EyeStep.OP_INFO("D2+m2", "rcl", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.CL
			}, "Rotate");
			array[741] = new EyeStep.OP_INFO("D2+m3", "rcr", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.CL
			}, "Rotate");
			array[742] = new EyeStep.OP_INFO("D2+m4", "shl", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.CL
			}, "Shift");
			array[743] = new EyeStep.OP_INFO("D2+m5", "shr", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.CL
			}, "Shift");
			array[744] = new EyeStep.OP_INFO("D2+m6", "shl", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.CL
			}, "Shift");
			array[745] = new EyeStep.OP_INFO("D2+m7", "shr", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.CL
			}, "Shift");
			array[746] = new EyeStep.OP_INFO("D3+m0", "rol", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.CL
			}, "Rotate");
			array[747] = new EyeStep.OP_INFO("D3+m1", "ror", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.CL
			}, "Rotate");
			array[748] = new EyeStep.OP_INFO("D3+m2", "rcl", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.CL
			}, "Rotate");
			array[749] = new EyeStep.OP_INFO("D3+m3", "rcr", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.CL
			}, "Rotate");
			array[750] = new EyeStep.OP_INFO("D3+m4", "shl", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.CL
			}, "Shift");
			array[751] = new EyeStep.OP_INFO("D3+m5", "shr", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.CL
			}, "Shift");
			array[752] = new EyeStep.OP_INFO("D3+m6", "shl", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.CL
			}, "Shift");
			array[753] = new EyeStep.OP_INFO("D3+m7", "shr", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.CL
			}, "Shift");
			array[754] = new EyeStep.OP_INFO("D4", "aam", new OP_TYPES[]
			{
				OP_TYPES.AL,
				OP_TYPES.AH,
				OP_TYPES.imm8
			}, "ASCII Adjust AX After Multiply");
			array[755] = new EyeStep.OP_INFO("D5", "aad", new OP_TYPES[]
			{
				OP_TYPES.AL,
				OP_TYPES.AH,
				OP_TYPES.imm8
			}, "ASCII Adjust AX Before Division");
			array[756] = new EyeStep.OP_INFO("D6", "setalc", new OP_TYPES[1], "Set AL If Carry");
			array[757] = new EyeStep.OP_INFO("D7", "xlatb", new OP_TYPES[1], "Table Look-up Translation");
			array[758] = new EyeStep.OP_INFO("D8+m8", "fadd", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "Add");
			array[759] = new EyeStep.OP_INFO("D8+m9", "fmul", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "Multiply");
			array[760] = new EyeStep.OP_INFO("D8+mA", "fcom", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "Compare Real");
			array[761] = new EyeStep.OP_INFO("D8+mB", "fcomp", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "Compare Real and Pop");
			array[762] = new EyeStep.OP_INFO("D8+mC", "fsub", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "Subtract");
			array[763] = new EyeStep.OP_INFO("D8+mD", "fsubr", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "Reverse Subtract");
			array[764] = new EyeStep.OP_INFO("D8+mE", "fdiv", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "Divide");
			array[765] = new EyeStep.OP_INFO("D8+mF", "fdivr", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "Reverse Divide");
			array[766] = new EyeStep.OP_INFO("D8+m0", "fadd", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Add");
			array[767] = new EyeStep.OP_INFO("D8+m1", "fmul", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Multiply");
			array[768] = new EyeStep.OP_INFO("D8+m2", "fcom", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Compare Real");
			array[769] = new EyeStep.OP_INFO("D8+m3", "fcomp", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Compare Real and Pop");
			array[770] = new EyeStep.OP_INFO("D8+m4", "fsub", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Subtract");
			array[771] = new EyeStep.OP_INFO("D8+m5", "fsubr", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Reverse Subtract");
			array[772] = new EyeStep.OP_INFO("D8+m6", "fdiv", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Divide");
			array[773] = new EyeStep.OP_INFO("D8+m7", "fdivr", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Reverse Divide");
			array[774] = new EyeStep.OP_INFO("D9+m0", "fld", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Load Floating Point Value");
			array[775] = new EyeStep.OP_INFO("D9+m1", "fxch", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Exchange Register Contents");
			array[776] = new EyeStep.OP_INFO("D9+m2", "fst", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Store Floating Point Value");
			array[777] = new EyeStep.OP_INFO("D9+m3", "fstp", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Store Floating Point Value and Pop");
			array[778] = new EyeStep.OP_INFO("D9+m4", "fldenv", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Load x87 FPU Environment");
			array[779] = new EyeStep.OP_INFO("D9+m5", "fldcw", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Load x87 FPU Control Word");
			array[780] = new EyeStep.OP_INFO("D9+m6", "fnstenv", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Store x87 FPU Environment");
			array[781] = new EyeStep.OP_INFO("D9+m7", "fnstcw", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Store x87 FPU Control Word");
			array[782] = new EyeStep.OP_INFO("DA+m8", "fcmovb", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "FP Conditional Move - below (CF=1)");
			array[783] = new EyeStep.OP_INFO("DA+m9", "fcmove", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "FP Conditional Move - equal (ZF=1)");
			array[784] = new EyeStep.OP_INFO("DA+mA", "fcmovbe", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "FP Conditional Move - below or equal (CF=1 or ZF=1)");
			array[785] = new EyeStep.OP_INFO("DA+mB", "fcmovu", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "FP Conditional Move - unordered (PF=1)");
			array[786] = new EyeStep.OP_INFO("DA+mC", "fisub", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "Subtract");
			array[787] = new EyeStep.OP_INFO("DA+mD", "fisubr", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "Reverse Subtract");
			array[788] = new EyeStep.OP_INFO("DA+mE", "fidiv", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "Divide");
			array[789] = new EyeStep.OP_INFO("DA+mF", "fidivr", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "Reverse Divide");
			array[790] = new EyeStep.OP_INFO("DA+m0", "fiadd", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Add");
			array[791] = new EyeStep.OP_INFO("DA+m1", "fimul", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Multiply");
			array[792] = new EyeStep.OP_INFO("DA+m2", "ficom", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Compare Real");
			array[793] = new EyeStep.OP_INFO("DA+m3", "ficomp", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Compare Real and Pop");
			array[794] = new EyeStep.OP_INFO("DA+m4", "fisub", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Subtract");
			array[795] = new EyeStep.OP_INFO("DA+m5", "fisubr", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Reverse Subtract");
			array[796] = new EyeStep.OP_INFO("DA+m6", "fidiv", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Divide");
			array[797] = new EyeStep.OP_INFO("DA+m7", "fidivr", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Reverse Divide");
			array[798] = new EyeStep.OP_INFO("DB+m8", "fcmovnb", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "FP Conditional Move - not below (CF=0)");
			array[799] = new EyeStep.OP_INFO("DB+m9", "fcmovne", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "FP Conditional Move - not equal (ZF=0)");
			array[800] = new EyeStep.OP_INFO("DB+mA", "fcmovnbe", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "FP Conditional Move - below or equal (CF=0 and ZF=0)");
			array[801] = new EyeStep.OP_INFO("DB+mB", "fcmovnu", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "FP Conditional Move - not unordered (PF=0)");
			array[802] = new EyeStep.OP_INFO("DB+m0", "fild", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Load Integer");
			array[803] = new EyeStep.OP_INFO("DB+m1", "fisttp", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Store Integer with Truncation and Pop");
			array[804] = new EyeStep.OP_INFO("DB+m2", "fist", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Store Integer");
			array[805] = new EyeStep.OP_INFO("DB+m3", "fistp", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Store Integer and Pop");
			array[806] = new EyeStep.OP_INFO("DB+m4", "finit", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Initialize Floating-Point Unit");
			array[807] = new EyeStep.OP_INFO("DB+m5", "fucomi", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Unordered Compare Floating Point Values and Set EFLAGS");
			array[808] = new EyeStep.OP_INFO("DB+m6", "fcomi", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Compare Floating Point Values and Set EFLAGS");
			array[809] = new EyeStep.OP_INFO("DB+m7", "fstp", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Store Floating Point Value and Pop");
			array[810] = new EyeStep.OP_INFO("DC+m8", "fadd", new OP_TYPES[]
			{
				OP_TYPES.STi,
				OP_TYPES.ST
			}, "Add");
			array[811] = new EyeStep.OP_INFO("DC+m9", "fmul", new OP_TYPES[]
			{
				OP_TYPES.STi,
				OP_TYPES.ST
			}, "Multiply");
			array[812] = new EyeStep.OP_INFO("DC+mA", "fcom", new OP_TYPES[]
			{
				OP_TYPES.STi,
				OP_TYPES.ST
			}, "Compare Real");
			array[813] = new EyeStep.OP_INFO("DC+mB", "fcomp", new OP_TYPES[]
			{
				OP_TYPES.STi,
				OP_TYPES.ST
			}, "Compare Real and Pop");
			array[814] = new EyeStep.OP_INFO("DC+mC", "fsub", new OP_TYPES[]
			{
				OP_TYPES.STi,
				OP_TYPES.ST
			}, "Subtract");
			array[815] = new EyeStep.OP_INFO("DC+mD", "fsubr", new OP_TYPES[]
			{
				OP_TYPES.STi,
				OP_TYPES.ST
			}, "Reverse Subtract");
			array[816] = new EyeStep.OP_INFO("DC+mE", "fdiv", new OP_TYPES[]
			{
				OP_TYPES.STi,
				OP_TYPES.ST
			}, "Divide");
			array[817] = new EyeStep.OP_INFO("DC+mF", "fdivr", new OP_TYPES[]
			{
				OP_TYPES.STi,
				OP_TYPES.ST
			}, "Reverse Divide");
			array[818] = new EyeStep.OP_INFO("DC+m0", "fadd", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Add");
			array[819] = new EyeStep.OP_INFO("DC+m1", "fmul", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Multiply");
			array[820] = new EyeStep.OP_INFO("DC+m2", "fcom", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Compare Real");
			array[821] = new EyeStep.OP_INFO("DC+m3", "fcomp", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Compare Real and Pop");
			array[822] = new EyeStep.OP_INFO("DC+m4", "fsub", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Subtract");
			array[823] = new EyeStep.OP_INFO("DC+m5", "fsubr", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Reverse Subtract");
			array[824] = new EyeStep.OP_INFO("DC+m6", "fdiv", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Divide");
			array[825] = new EyeStep.OP_INFO("DC+m7", "fdivr", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Reverse Divide");
			array[826] = new EyeStep.OP_INFO("DD+m8", "ffree", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Free Floating-Point Register");
			array[827] = new EyeStep.OP_INFO("DD+m0", "fld", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Load Floating Point Value");
			array[828] = new EyeStep.OP_INFO("DD+m1", "fisttp", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Store Integer with Truncation and Pop");
			array[829] = new EyeStep.OP_INFO("DD+m2", "fst", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Store Floating Point Value");
			array[830] = new EyeStep.OP_INFO("DD+m3", "fstp", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Store Floating Point Value and Pop");
			array[831] = new EyeStep.OP_INFO("DD+m4", "frstor", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Restore x87 FPU State");
			array[832] = new EyeStep.OP_INFO("DD+m5", "fucomp", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Unordered Compare Floating Point Values and Pop");
			array[833] = new EyeStep.OP_INFO("DD+m6", "fnsave", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Store x87 FPU State");
			array[834] = new EyeStep.OP_INFO("DD+m7", "fnstsw", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Store x87 FPU Status Word");
			array[835] = new EyeStep.OP_INFO("DE+m8", "faddp", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "Add and Pop");
			array[836] = new EyeStep.OP_INFO("DE+m9", "fmulp", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "Multiply and Pop");
			array[837] = new EyeStep.OP_INFO("DE+mA", "ficom", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "Compare Real");
			array[838] = new EyeStep.OP_INFO("DE+mB", "ficomp", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "Compare Real and Pop");
			array[839] = new EyeStep.OP_INFO("DE+mC", "fsubrp", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "Reverse Subtract and Pop");
			array[840] = new EyeStep.OP_INFO("DE+mD", "fsubp", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "Subtract and Pop");
			array[841] = new EyeStep.OP_INFO("DE+mE", "fdivrp", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "Reverse Divide and Pop");
			array[842] = new EyeStep.OP_INFO("DE+mF", "fdivp", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "Divide and Pop");
			array[843] = new EyeStep.OP_INFO("DE+m0", "fiadd", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Add");
			array[844] = new EyeStep.OP_INFO("DE+m1", "fimul", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Multiply");
			array[845] = new EyeStep.OP_INFO("DE+m2", "ficom", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Compare Real");
			array[846] = new EyeStep.OP_INFO("DE+m3", "ficomp", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Compare Real and Pop");
			array[847] = new EyeStep.OP_INFO("DE+m4", "fisub", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Subtract");
			array[848] = new EyeStep.OP_INFO("DE+m5", "fisubr", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Reverse Subtract");
			array[849] = new EyeStep.OP_INFO("DE+m6", "fidiv", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Divide");
			array[850] = new EyeStep.OP_INFO("DE+m7", "fdivr", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Reverse Divide");
			array[851] = new EyeStep.OP_INFO("DF+m8", "ffreep", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Free Floating-Point Register and Pop");
			array[852] = new EyeStep.OP_INFO("DF+m9", "fisttp", new OP_TYPES[]
			{
				OP_TYPES.r32
			}, "Store Integer with Truncation and Pop");
			array[853] = new EyeStep.OP_INFO("DF+mA", "fist", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Store Integer");
			array[854] = new EyeStep.OP_INFO("DF+mB", "fistp", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Store Integer and Pop");
			array[855] = new EyeStep.OP_INFO("DF+mC", "fnstsw", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Store x87 FPU Status Word");
			array[856] = new EyeStep.OP_INFO("DF+mD", "fucomip", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "Unordered Compare Floating Point Values and Set EFLAGS and Pop");
			array[857] = new EyeStep.OP_INFO("DF+mE", "fcomip", new OP_TYPES[]
			{
				OP_TYPES.ST,
				OP_TYPES.STi
			}, "Compare Floating Point Values and Set EFLAGS and Pop");
			array[858] = new EyeStep.OP_INFO("DF+mF", "fistp", new OP_TYPES[]
			{
				OP_TYPES.r64
			}, "Store Integer and Pop");
			array[859] = new EyeStep.OP_INFO("DF+m0", "fild", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Load Integer");
			array[860] = new EyeStep.OP_INFO("DF+m1", "fisttp", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Store Integer with Truncation and Pop");
			array[861] = new EyeStep.OP_INFO("DF+m2", "fist", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Store Integer");
			array[862] = new EyeStep.OP_INFO("DF+m3", "fistp", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Store Integer and Pop");
			array[863] = new EyeStep.OP_INFO("DF+m4", "fbld", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Load Binary Coded Decimal");
			array[864] = new EyeStep.OP_INFO("DF+m5", "fild", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Load Integer");
			array[865] = new EyeStep.OP_INFO("DF+m6", "fbstp", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Store BCD Integer and Pop");
			array[866] = new EyeStep.OP_INFO("DF+m7", "fistp", new OP_TYPES[]
			{
				OP_TYPES.STi
			}, "Store Integer and Pop");
			array[867] = new EyeStep.OP_INFO("E0", "loopne", new OP_TYPES[]
			{
				OP_TYPES.ECX,
				OP_TYPES.rel8
			}, "Decrement count; Jump short if count!=0 and ZF=0");
			array[868] = new EyeStep.OP_INFO("E1", "loope", new OP_TYPES[]
			{
				OP_TYPES.ECX,
				OP_TYPES.rel8
			}, "Decrement count; Jump short if count!=0 and ZF=1");
			array[869] = new EyeStep.OP_INFO("E2", "loop", new OP_TYPES[]
			{
				OP_TYPES.ECX,
				OP_TYPES.rel8
			}, "Decrement count; Jump short if count!=0");
			array[870] = new EyeStep.OP_INFO("E3", "jecxz", new OP_TYPES[]
			{
				OP_TYPES.rel8
			}, "Jump short if eCX register is 0");
			array[871] = new EyeStep.OP_INFO("E4", "in", new OP_TYPES[]
			{
				OP_TYPES.AL,
				OP_TYPES.imm8
			}, "Input from Port");
			array[872] = new EyeStep.OP_INFO("E5", "in", new OP_TYPES[]
			{
				OP_TYPES.EAX,
				OP_TYPES.imm8
			}, "Input from Port");
			int num4 = 873;
			string a4 = "E6";
			string b4 = "out";
			OP_TYPES[] array5 = new OP_TYPES[2];
			array5[0] = OP_TYPES.imm8;
			array[num4] = new EyeStep.OP_INFO(a4, b4, array5, "Output to Port");
			array[874] = new EyeStep.OP_INFO("E7", "out", new OP_TYPES[]
			{
				OP_TYPES.imm8,
				OP_TYPES.EAX
			}, "Output to Port");
			array[875] = new EyeStep.OP_INFO("E8", "call", new OP_TYPES[]
			{
				OP_TYPES.rel16_32
			}, "Call Procedure");
			array[876] = new EyeStep.OP_INFO("E9", "jmp", new OP_TYPES[]
			{
				OP_TYPES.rel16_32
			}, "Jump");
			array[877] = new EyeStep.OP_INFO("EA", "jmpf", new OP_TYPES[]
			{
				OP_TYPES.ptr16_32
			}, "Jump");
			array[878] = new EyeStep.OP_INFO("EB", "jmp short", new OP_TYPES[]
			{
				OP_TYPES.rel8
			}, "Jump");
			array[879] = new EyeStep.OP_INFO("EC", "in", new OP_TYPES[]
			{
				OP_TYPES.AL,
				OP_TYPES.DX
			}, "Input from Port");
			array[880] = new EyeStep.OP_INFO("ED", "in", new OP_TYPES[]
			{
				OP_TYPES.EAX,
				OP_TYPES.DX
			}, "Input from Port");
			int num5 = 881;
			string a5 = "EE";
			string b5 = "out";
			OP_TYPES[] array6 = new OP_TYPES[2];
			array6[0] = OP_TYPES.DX;
			array[num5] = new EyeStep.OP_INFO(a5, b5, array6, "Output to Port");
			array[882] = new EyeStep.OP_INFO("EF", "out", new OP_TYPES[]
			{
				OP_TYPES.DX,
				OP_TYPES.EAX
			}, "Output to Port");
			array[883] = new EyeStep.OP_INFO("F1", "int 1", new OP_TYPES[0], "Call to Interrupt Procedure");
			array[884] = new EyeStep.OP_INFO("F4", "hlt", new OP_TYPES[0], "Halt");
			array[885] = new EyeStep.OP_INFO("F5", "cmc", new OP_TYPES[0], "Complement Carry Flag");
			array[886] = new EyeStep.OP_INFO("F6+m0", "test", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.imm8
			}, "Logical Compare");
			array[887] = new EyeStep.OP_INFO("F6+m1", "test", new OP_TYPES[]
			{
				OP_TYPES.r_m8,
				OP_TYPES.imm8
			}, "Logical Compare");
			array[888] = new EyeStep.OP_INFO("F6+m2", "not", new OP_TYPES[]
			{
				OP_TYPES.r_m8
			}, "One's Complement Negation");
			array[889] = new EyeStep.OP_INFO("F6+m3", "neg", new OP_TYPES[]
			{
				OP_TYPES.r_m8
			}, "Two's Complement Negation");
			array[890] = new EyeStep.OP_INFO("F6+m4", "mul", new OP_TYPES[]
			{
				OP_TYPES.AX,
				OP_TYPES.AL,
				OP_TYPES.r_m8
			}, "Unsigned Multiply");
			array[891] = new EyeStep.OP_INFO("F6+m5", "imul", new OP_TYPES[]
			{
				OP_TYPES.AX,
				OP_TYPES.AL,
				OP_TYPES.r_m8
			}, "Signed Multiply");
			array[892] = new EyeStep.OP_INFO("F6+m6", "div", new OP_TYPES[]
			{
				OP_TYPES.AX,
				OP_TYPES.AL,
				OP_TYPES.AX,
				OP_TYPES.r_m8
			}, "Unigned Divide");
			array[893] = new EyeStep.OP_INFO("F6+m7", "idiv", new OP_TYPES[]
			{
				OP_TYPES.AX,
				OP_TYPES.AL,
				OP_TYPES.AX,
				OP_TYPES.r_m8
			}, "Signed Divide");
			array[894] = new EyeStep.OP_INFO("F7+m0", "test", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm16_32
			}, "Logical Compare");
			array[895] = new EyeStep.OP_INFO("F7+m1", "test", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32,
				OP_TYPES.imm16_32
			}, "Logical Compare");
			array[896] = new EyeStep.OP_INFO("F7+m2", "not", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "One's Complement Negation");
			array[897] = new EyeStep.OP_INFO("F7+m3", "neg", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Two's Complement Negation");
			array[898] = new EyeStep.OP_INFO("F7+m4", "mul", new OP_TYPES[]
			{
				OP_TYPES.EDX,
				OP_TYPES.EAX,
				OP_TYPES.r_m16_32
			}, "Unsigned Multiply");
			array[899] = new EyeStep.OP_INFO("F7+m5", "imul", new OP_TYPES[]
			{
				OP_TYPES.EDX,
				OP_TYPES.EAX,
				OP_TYPES.r_m16_32
			}, "Signed Multiply");
			array[900] = new EyeStep.OP_INFO("F7+m6", "div", new OP_TYPES[]
			{
				OP_TYPES.EDX,
				OP_TYPES.EAX,
				OP_TYPES.r_m16_32
			}, "Unigned Divide");
			array[901] = new EyeStep.OP_INFO("F7+m7", "idiv", new OP_TYPES[]
			{
				OP_TYPES.EDX,
				OP_TYPES.EAX,
				OP_TYPES.r_m16_32
			}, "Signed Divide");
			array[902] = new EyeStep.OP_INFO("F8", "clc", new OP_TYPES[0], "Clear Carry Flag");
			array[903] = new EyeStep.OP_INFO("F9", "stc", new OP_TYPES[0], "Set Carry Flag");
			array[904] = new EyeStep.OP_INFO("FA", "cli", new OP_TYPES[0], "Clear Interrupt Flag");
			array[905] = new EyeStep.OP_INFO("FB", "sti", new OP_TYPES[0], "Set Interrupt Flag");
			array[906] = new EyeStep.OP_INFO("FC", "cld", new OP_TYPES[0], "Clear Direction Flag");
			array[907] = new EyeStep.OP_INFO("FD", "std", new OP_TYPES[0], "Set Direction Flag");
			array[908] = new EyeStep.OP_INFO("FE+m0", "inc", new OP_TYPES[]
			{
				OP_TYPES.r_m8
			}, "Increment by 1");
			array[909] = new EyeStep.OP_INFO("FE+m1", "dec", new OP_TYPES[]
			{
				OP_TYPES.r_m8
			}, "Decrement by 1");
			array[910] = new EyeStep.OP_INFO("FE+mE", "inc", new OP_TYPES[]
			{
				OP_TYPES.r_m8
			}, "Increment by 1");
			array[911] = new EyeStep.OP_INFO("FE+mF", "dec", new OP_TYPES[]
			{
				OP_TYPES.r_m8
			}, "Decrement by 1");
			array[912] = new EyeStep.OP_INFO("FF+m0", "inc", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Increment by 1");
			array[913] = new EyeStep.OP_INFO("FF+m1", "dec", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Decrement by 1");
			array[914] = new EyeStep.OP_INFO("FF+m2", "call", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Call Procedure");
			array[915] = new EyeStep.OP_INFO("FF+m3", "callf", new OP_TYPES[]
			{
				OP_TYPES.m16_32_and_16_32
			}, "Call Procedure");
			array[916] = new EyeStep.OP_INFO("FF+m4", "jmp", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Jump");
			array[917] = new EyeStep.OP_INFO("FF+m5", "jmpf", new OP_TYPES[]
			{
				OP_TYPES.m16_32_and_16_32
			}, "Jump");
			array[918] = new EyeStep.OP_INFO("FF+m6", "push", new OP_TYPES[]
			{
				OP_TYPES.r_m16_32
			}, "Push Word, Doubleword or Quadword Onto the Stack");
			EyeStep.OP_TABLE = array;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000C694 File Offset: 0x0000A894
		private static byte to_byte(string str, int offset)
		{
			int num = 0;
			if (str[offset] == '?' && str[offset + 1] == '?')
			{
				return 0;
			}
			for (int i = offset; i < offset + 2; i++)
			{
				int num2 = 0;
				if (str[i] >= 'a')
				{
					num2 = (int)(str[i] - 'W');
				}
				else if (str[i] >= 'A')
				{
					num2 = (int)(str[i] - '7');
				}
				else if (str[i] >= '0')
				{
					num2 = (int)(str[i] - '0');
				}
				if (i == offset)
				{
					num += num2 * 16;
				}
				else
				{
					num += num2;
				}
			}
			return (byte)num;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x0000C726 File Offset: 0x0000A926
		public static string to_str(byte b)
		{
			return b.ToString("X2");
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000C734 File Offset: 0x0000A934
		public static void open(string process_name)
		{
			if (EyeStep.OP_TABLE == null)
			{
				EyeStep.init();
			}
			Process[] processesByName = Process.GetProcessesByName(process_name.Replace(".exe", ""));
			if (processesByName.Length != 0)
			{
				EyeStep.current_proc = processesByName.First<Process>();
				if (EyeStep.current_proc.Id != 0)
				{
					EyeStep.base_module = EyeStep.current_proc.MainModule.BaseAddress.ToInt32();
					EyeStep.base_module_size = EyeStep.current_proc.MainModule.ModuleMemorySize;
					EyeStep.handle = imports.OpenProcess(2035711U, false, EyeStep.current_proc.Id);
				}
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000C7C8 File Offset: 0x0000A9C8
		public static EyeStep.inst read(int address)
		{
			EyeStep.<>c__DisplayClass86_0 CS$<>8__locals1;
			CS$<>8__locals1.p = new EyeStep.inst();
			CS$<>8__locals1.p.address = address;
			int num = 0;
			imports.ReadProcessMemory(EyeStep.handle, address, CS$<>8__locals1.p.bytes, 16, ref num);
			for (int i = 0; i < EyeStep.OP_TABLE.Length; i++)
			{
				EyeStep.OP_INFO op_INFO = EyeStep.OP_TABLE[i];
				CS$<>8__locals1.p.flags = 0U;
				CS$<>8__locals1.p.len = 0;
				byte b = EyeStep.to_byte(op_INFO.code, 0);
				bool flag = false;
				byte b2 = CS$<>8__locals1.p.bytes[CS$<>8__locals1.p.len];
				if (b2 <= 54)
				{
					if (b2 != 38)
					{
						if (b2 != 46)
						{
							if (b2 == 54)
							{
								CS$<>8__locals1.p.len++;
								CS$<>8__locals1.p.flags |= 64U;
							}
						}
						else
						{
							CS$<>8__locals1.p.len++;
							CS$<>8__locals1.p.flags |= 32U;
						}
					}
					else
					{
						CS$<>8__locals1.p.len++;
						CS$<>8__locals1.p.flags |= 256U;
					}
				}
				else if (b2 != 62)
				{
					switch (b2)
					{
					case 100:
						CS$<>8__locals1.p.len++;
						CS$<>8__locals1.p.flags |= 512U;
						break;
					case 101:
						CS$<>8__locals1.p.len++;
						CS$<>8__locals1.p.flags |= 1024U;
						break;
					case 102:
						CS$<>8__locals1.p.flags |= 4U;
						break;
					case 103:
						CS$<>8__locals1.p.flags |= 8U;
						break;
					default:
						switch (b2)
						{
						case 240:
							CS$<>8__locals1.p.flags |= 16U;
							if (b != 240)
							{
								flag = true;
							}
							break;
						case 242:
							CS$<>8__locals1.p.flags |= 1U;
							if (b != 242)
							{
								flag = true;
							}
							break;
						case 243:
							CS$<>8__locals1.p.flags |= 2U;
							if (b != 243)
							{
								flag = true;
							}
							break;
						}
						break;
					}
				}
				else
				{
					CS$<>8__locals1.p.len++;
					CS$<>8__locals1.p.flags |= 128U;
				}
				bool flag2 = CS$<>8__locals1.p.bytes[CS$<>8__locals1.p.len] == b;
				bool flag3 = false;
				int num2 = 2;
				while (num2 < 11 && op_INFO.code.Length > num2)
				{
					if (op_INFO.code[num2] == '+')
					{
						if (op_INFO.code[num2 + 1] == 'r')
						{
							flag3 = true;
							flag2 = (CS$<>8__locals1.p.bytes[CS$<>8__locals1.p.len] >= b && CS$<>8__locals1.p.bytes[CS$<>8__locals1.p.len] < b + 8);
							break;
						}
						if (op_INFO.code[num2 + 1] == 'm' && flag2)
						{
							byte b3 = EyeStep.to_byte("0" + op_INFO.code[num2 + 2].ToString(), 0);
							if (b3 >= 0 && b3 < 8)
							{
								flag2 = (EyeStep.longreg(CS$<>8__locals1.p.bytes[CS$<>8__locals1.p.len + 1]) == (int)b3);
								break;
							}
							b3 -= 8;
							flag2 = (EyeStep.longreg(CS$<>8__locals1.p.bytes[CS$<>8__locals1.p.len + 1]) == (int)b3 && CS$<>8__locals1.p.bytes[CS$<>8__locals1.p.len + 1] >= 192);
							break;
						}
						else if (flag2)
						{
							CS$<>8__locals1.p.len++;
							b = EyeStep.to_byte(op_INFO.code, num2 + 1);
							flag2 = (CS$<>8__locals1.p.bytes[CS$<>8__locals1.p.len] == b);
						}
					}
					num2 += 3;
				}
				if (flag2)
				{
					CS$<>8__locals1.p.len++;
					if (flag)
					{
						uint num3 = CS$<>8__locals1.p.flags;
						if (num3 != 1U)
						{
							if (num3 != 2U)
							{
								if (num3 == 16U)
								{
									CS$<>8__locals1.p.data = "lock ";
								}
							}
							else
							{
								CS$<>8__locals1.p.data = "repe ";
							}
						}
						else
						{
							CS$<>8__locals1.p.data = "repne ";
						}
					}
					EyeStep.inst p = CS$<>8__locals1.p;
					p.data += op_INFO.opcode_name;
					EyeStep.inst p2 = CS$<>8__locals1.p;
					p2.data += " ";
					CS$<>8__locals1.p.info = op_INFO;
					int num4 = op_INFO.operands.Length;
					switch (num4)
					{
					case 0:
						break;
					case 1:
						CS$<>8__locals1.p.flags |= 1U;
						break;
					case 2:
						CS$<>8__locals1.p.flags |= 2U;
						break;
					default:
						CS$<>8__locals1.p.flags |= 4U;
						break;
					}
					byte b4 = byte.MaxValue;
					EyeStep.<>c__DisplayClass86_1 CS$<>8__locals2;
					CS$<>8__locals2.c = 0;
					while (CS$<>8__locals2.c < num4)
					{
						CS$<>8__locals1.p.operands[CS$<>8__locals2.c].opmode = op_INFO.operands[CS$<>8__locals2.c];
						byte b5 = b4;
						if (b4 == 255)
						{
							b5 = (byte)EyeStep.longreg(CS$<>8__locals1.p.bytes[CS$<>8__locals1.p.len]);
						}
						if (flag3)
						{
							b5 = (byte)EyeStep.finalreg(CS$<>8__locals1.p.bytes[CS$<>8__locals1.p.len - 1]);
						}
						switch (CS$<>8__locals1.p.operands[CS$<>8__locals2.c].opmode)
						{
						case OP_TYPES.AL:
						{
							CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(0);
							EyeStep.inst p3 = CS$<>8__locals1.p;
							p3.data += "al";
							CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 1024U;
							break;
						}
						case OP_TYPES.AH:
						{
							CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(4);
							EyeStep.inst p4 = CS$<>8__locals1.p;
							p4.data += "ah";
							CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 1024U;
							break;
						}
						case OP_TYPES.AX:
						{
							CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(0);
							EyeStep.inst p5 = CS$<>8__locals1.p;
							p5.data += "ax";
							CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 2048U;
							break;
						}
						case OP_TYPES.EAX:
						{
							CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(0);
							EyeStep.inst p6 = CS$<>8__locals1.p;
							p6.data += "eax";
							CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 4096U;
							break;
						}
						case OP_TYPES.ECX:
						{
							CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(1);
							EyeStep.inst p7 = CS$<>8__locals1.p;
							p7.data += "ecx";
							CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 4096U;
							break;
						}
						case OP_TYPES.EBP:
						{
							CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(3);
							EyeStep.inst p8 = CS$<>8__locals1.p;
							p8.data += "ebp";
							CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 4096U;
							break;
						}
						case OP_TYPES.CL:
						{
							CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(1);
							EyeStep.inst p9 = CS$<>8__locals1.p;
							p9.data += "cl";
							CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 1024U;
							break;
						}
						case OP_TYPES.Sreg:
						{
							EyeStep.inst p10 = CS$<>8__locals1.p;
							p10.data += EyeStep.mnemonics.sreg_names[(int)CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(b5)];
							CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 131072U;
							break;
						}
						case OP_TYPES.ptr16_32:
						{
							EyeStep.<read>g__get_imm32|86_2(BitConverter.ToUInt32(CS$<>8__locals1.p.bytes, CS$<>8__locals1.p.len), true, ref CS$<>8__locals1, ref CS$<>8__locals2);
							EyeStep.inst p11 = CS$<>8__locals1.p;
							p11.data += ":";
							EyeStep.<read>g__get_imm16|86_1(BitConverter.ToUInt16(CS$<>8__locals1.p.bytes, CS$<>8__locals1.p.len), true, ref CS$<>8__locals1, ref CS$<>8__locals2);
							break;
						}
						case OP_TYPES.ES:
						{
							EyeStep.inst p12 = CS$<>8__locals1.p;
							p12.data += "es";
							break;
						}
						case OP_TYPES.DS:
						{
							EyeStep.inst p13 = CS$<>8__locals1.p;
							p13.data += "ds";
							break;
						}
						case OP_TYPES.SS:
						{
							EyeStep.inst p14 = CS$<>8__locals1.p;
							p14.data += "ss";
							break;
						}
						case OP_TYPES.FS:
						{
							EyeStep.inst p15 = CS$<>8__locals1.p;
							p15.data += "fs";
							break;
						}
						case OP_TYPES.GS:
						{
							EyeStep.inst p16 = CS$<>8__locals1.p;
							p16.data += "gs";
							break;
						}
						case OP_TYPES.one:
						{
							CS$<>8__locals1.p.operands[CS$<>8__locals2.c].disp32 = (uint)(CS$<>8__locals1.p.operands[CS$<>8__locals2.c].disp16 = (ushort)(CS$<>8__locals1.p.operands[CS$<>8__locals2.c].disp8 = 1));
							EyeStep.inst p17 = CS$<>8__locals1.p;
							p17.data += "1";
							break;
						}
						case OP_TYPES.r8:
						{
							EyeStep.inst p18 = CS$<>8__locals1.p;
							p18.data += EyeStep.mnemonics.r8_names[(int)CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(b5)];
							CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 1024U;
							break;
						}
						case OP_TYPES.r16:
						{
							EyeStep.inst p19 = CS$<>8__locals1.p;
							p19.data += EyeStep.mnemonics.r16_names[(int)CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(b5)];
							CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 2048U;
							break;
						}
						case OP_TYPES.r16_32:
						case OP_TYPES.r32:
						{
							EyeStep.inst p20 = CS$<>8__locals1.p;
							p20.data += EyeStep.mnemonics.r32_names[(int)CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(b5)];
							CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 4096U;
							break;
						}
						case OP_TYPES.r64:
						{
							EyeStep.inst p21 = CS$<>8__locals1.p;
							p21.data += EyeStep.mnemonics.r64_names[(int)CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(b5)];
							CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 8192U;
							break;
						}
						case OP_TYPES.r_m8:
						case OP_TYPES.r_m16:
						case OP_TYPES.r_m16_32:
						case OP_TYPES.r_m32:
						case OP_TYPES.m16_32_and_16_32:
						case OP_TYPES.m8:
						case OP_TYPES.m16:
						case OP_TYPES.m16_32:
						case OP_TYPES.m32:
						case OP_TYPES.m64real:
						case OP_TYPES.m128:
						case OP_TYPES.mm_m64:
						case OP_TYPES.xmm_m32:
						case OP_TYPES.xmm_m64:
						case OP_TYPES.xmm_m128:
						case OP_TYPES.STi:
							if ((CS$<>8__locals1.p.flags & 32U) == 32U)
							{
								EyeStep.inst p22 = CS$<>8__locals1.p;
								p22.data += "cs:";
							}
							else if ((CS$<>8__locals1.p.flags & 128U) == 128U)
							{
								EyeStep.inst p23 = CS$<>8__locals1.p;
								p23.data += "ds:";
							}
							else if ((CS$<>8__locals1.p.flags & 256U) == 256U)
							{
								EyeStep.inst p24 = CS$<>8__locals1.p;
								p24.data += "es:";
							}
							else if ((CS$<>8__locals1.p.flags & 64U) == 64U)
							{
								EyeStep.inst p25 = CS$<>8__locals1.p;
								p25.data += "ss:";
							}
							else if ((CS$<>8__locals1.p.flags & 512U) == 512U)
							{
								EyeStep.inst p26 = CS$<>8__locals1.p;
								p26.data += "fs:";
							}
							else if ((CS$<>8__locals1.p.flags & 1024U) == 1024U)
							{
								EyeStep.inst p27 = CS$<>8__locals1.p;
								p27.data += "gs:";
							}
							if (CS$<>8__locals2.c == 0)
							{
								b4 = b5;
							}
							b5 = (byte)EyeStep.finalreg(CS$<>8__locals1.p.bytes[CS$<>8__locals1.p.len]);
							switch (CS$<>8__locals1.p.bytes[CS$<>8__locals1.p.len] / 64)
							{
							case 0:
							{
								EyeStep.inst p28 = CS$<>8__locals1.p;
								p28.data += "[";
								if (b5 != 4)
								{
									if (b5 != 5)
									{
										EyeStep.inst p29 = CS$<>8__locals1.p;
										p29.data += EyeStep.mnemonics.r32_names[(int)CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(b5)];
										CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 4096U;
									}
									else
									{
										EyeStep.inst p30 = CS$<>8__locals1.p;
										string data = p30.data;
										uint num3 = CS$<>8__locals1.p.operands[CS$<>8__locals2.c].disp32 = BitConverter.ToUInt32(CS$<>8__locals1.p.bytes, CS$<>8__locals1.p.len + 1);
										p30.data = data + num3.ToString("X8");
										CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 512U;
										CS$<>8__locals1.p.len += 4;
									}
								}
								else
								{
									EyeStep.<read>g__get_sib|86_3(0, ref CS$<>8__locals1, ref CS$<>8__locals2);
								}
								EyeStep.inst p31 = CS$<>8__locals1.p;
								p31.data += "]";
								break;
							}
							case 1:
							{
								EyeStep.inst p32 = CS$<>8__locals1.p;
								p32.data += "[";
								if (b5 == 4)
								{
									EyeStep.<read>g__get_sib|86_3(1, ref CS$<>8__locals1, ref CS$<>8__locals2);
								}
								else
								{
									EyeStep.inst p33 = CS$<>8__locals1.p;
									p33.data += EyeStep.mnemonics.r32_names[(int)CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(b5)];
									CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 4096U;
									EyeStep.<read>g__get_imm8|86_0(CS$<>8__locals1.p.bytes[CS$<>8__locals1.p.len + 1], false, ref CS$<>8__locals1, ref CS$<>8__locals2);
								}
								EyeStep.inst p34 = CS$<>8__locals1.p;
								p34.data += "]";
								break;
							}
							case 2:
							{
								EyeStep.inst p35 = CS$<>8__locals1.p;
								p35.data += "[";
								if (b5 == 4)
								{
									EyeStep.<read>g__get_sib|86_3(4, ref CS$<>8__locals1, ref CS$<>8__locals2);
								}
								else
								{
									EyeStep.inst p36 = CS$<>8__locals1.p;
									p36.data += EyeStep.mnemonics.r32_names[(int)CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(b5)];
									CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 4096U;
									EyeStep.<read>g__get_imm32|86_2(BitConverter.ToUInt32(CS$<>8__locals1.p.bytes, CS$<>8__locals1.p.len + 1), false, ref CS$<>8__locals1, ref CS$<>8__locals2);
								}
								EyeStep.inst p37 = CS$<>8__locals1.p;
								p37.data += "]";
								break;
							}
							case 3:
							{
								OP_TYPES opmode = CS$<>8__locals1.p.operands[CS$<>8__locals2.c].opmode;
								if (opmode <= OP_TYPES.m16)
								{
									if (opmode <= OP_TYPES.r_m16)
									{
										if (opmode == OP_TYPES.r_m8)
										{
											goto IL_11FB;
										}
										if (opmode != OP_TYPES.r_m16)
										{
											goto IL_14CC;
										}
									}
									else
									{
										if (opmode == OP_TYPES.m8)
										{
											goto IL_11FB;
										}
										if (opmode != OP_TYPES.m16)
										{
											goto IL_14CC;
										}
									}
									EyeStep.inst p38 = CS$<>8__locals1.p;
									p38.data += EyeStep.mnemonics.r16_names[(int)CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(b5)];
									CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 2048U;
									break;
									IL_11FB:
									EyeStep.inst p39 = CS$<>8__locals1.p;
									p39.data += EyeStep.mnemonics.r8_names[(int)CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(b5)];
									CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 1024U;
									break;
								}
								if (opmode <= OP_TYPES.ST)
								{
									if (opmode != OP_TYPES.m128)
									{
										switch (opmode)
										{
										case OP_TYPES.mm_m64:
										{
											EyeStep.inst p40 = CS$<>8__locals1.p;
											p40.data += EyeStep.mnemonics.mm_names[(int)CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(b5)];
											CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 32768U;
											goto IL_1834;
										}
										case OP_TYPES.xmm:
										case OP_TYPES.xmm0:
										case OP_TYPES.ST1:
										case OP_TYPES.ST2:
											goto IL_14CC;
										case OP_TYPES.xmm_m32:
										case OP_TYPES.xmm_m64:
										case OP_TYPES.xmm_m128:
											break;
										case OP_TYPES.STi:
										case OP_TYPES.ST:
										{
											EyeStep.inst p41 = CS$<>8__locals1.p;
											p41.data += EyeStep.mnemonics.st_names[(int)CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(b5)];
											CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 65536U;
											goto IL_1834;
										}
										default:
											goto IL_14CC;
										}
									}
									EyeStep.inst p42 = CS$<>8__locals1.p;
									p42.data += EyeStep.mnemonics.xmm_names[(int)CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(b5)];
									CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 16384U;
									break;
								}
								if (opmode == OP_TYPES.CRn)
								{
									EyeStep.inst p43 = CS$<>8__locals1.p;
									p43.data += EyeStep.mnemonics.cr_names[(int)CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(b5)];
									CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 524288U;
									break;
								}
								if (opmode == OP_TYPES.DRn)
								{
									EyeStep.inst p44 = CS$<>8__locals1.p;
									p44.data += EyeStep.mnemonics.dr_names[(int)CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(b5)];
									CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 262144U;
									break;
								}
								IL_14CC:
								EyeStep.inst p45 = CS$<>8__locals1.p;
								p45.data += EyeStep.mnemonics.r32_names[(int)CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(b5)];
								CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 4096U;
								break;
							}
							}
							IL_1834:
							CS$<>8__locals1.p.len++;
							break;
						case OP_TYPES.moffs8:
						{
							EyeStep.inst p46 = CS$<>8__locals1.p;
							p46.data += "[";
							EyeStep.<read>g__get_imm32|86_2(BitConverter.ToUInt32(CS$<>8__locals1.p.bytes, CS$<>8__locals1.p.len), true, ref CS$<>8__locals1, ref CS$<>8__locals2);
							EyeStep.inst p47 = CS$<>8__locals1.p;
							p47.data += "]";
							break;
						}
						case OP_TYPES.moffs16_32:
						{
							EyeStep.inst p48 = CS$<>8__locals1.p;
							p48.data += "[";
							EyeStep.<read>g__get_imm32|86_2(BitConverter.ToUInt32(CS$<>8__locals1.p.bytes, CS$<>8__locals1.p.len), true, ref CS$<>8__locals1, ref CS$<>8__locals2);
							EyeStep.inst p49 = CS$<>8__locals1.p;
							p49.data += "]";
							break;
						}
						case OP_TYPES.rel8:
							EyeStep.<read>g__get_rel8|86_4(CS$<>8__locals1.p.bytes[CS$<>8__locals1.p.len], ref CS$<>8__locals1, ref CS$<>8__locals2);
							break;
						case OP_TYPES.rel16:
							EyeStep.<read>g__get_rel16|86_5(BitConverter.ToUInt16(CS$<>8__locals1.p.bytes, CS$<>8__locals1.p.len), ref CS$<>8__locals1, ref CS$<>8__locals2);
							break;
						case OP_TYPES.rel16_32:
						case OP_TYPES.rel32:
							EyeStep.<read>g__get_rel32|86_6(BitConverter.ToUInt32(CS$<>8__locals1.p.bytes, CS$<>8__locals1.p.len), ref CS$<>8__locals1, ref CS$<>8__locals2);
							break;
						case OP_TYPES.imm8:
							EyeStep.<read>g__get_imm8|86_0(CS$<>8__locals1.p.bytes[CS$<>8__locals1.p.len], true, ref CS$<>8__locals1, ref CS$<>8__locals2);
							break;
						case OP_TYPES.imm16:
							EyeStep.<read>g__get_imm16|86_1(BitConverter.ToUInt16(CS$<>8__locals1.p.bytes, CS$<>8__locals1.p.len), true, ref CS$<>8__locals1, ref CS$<>8__locals2);
							break;
						case OP_TYPES.imm16_32:
						case OP_TYPES.imm32:
							EyeStep.<read>g__get_imm32|86_2(BitConverter.ToUInt32(CS$<>8__locals1.p.bytes, CS$<>8__locals1.p.len), true, ref CS$<>8__locals1, ref CS$<>8__locals2);
							break;
						case OP_TYPES.mm:
						{
							EyeStep.inst p50 = CS$<>8__locals1.p;
							p50.data += EyeStep.mnemonics.mm_names[(int)CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(b5)];
							CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 32768U;
							break;
						}
						case OP_TYPES.xmm:
						{
							EyeStep.inst p51 = CS$<>8__locals1.p;
							p51.data += EyeStep.mnemonics.xmm_names[(int)CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(b5)];
							CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 16384U;
							break;
						}
						case OP_TYPES.xmm0:
						{
							CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(0);
							EyeStep.inst p52 = CS$<>8__locals1.p;
							p52.data += "xmm0";
							CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 16384U;
							break;
						}
						case OP_TYPES.ST:
						{
							EyeStep.inst p53 = CS$<>8__locals1.p;
							p53.data += EyeStep.mnemonics.st_names[(int)CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(0)];
							CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 65536U;
							break;
						}
						case OP_TYPES.CRn:
						{
							EyeStep.inst p54 = CS$<>8__locals1.p;
							p54.data += EyeStep.mnemonics.cr_names[(int)CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(b5)];
							CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 524288U;
							break;
						}
						case OP_TYPES.DRn:
						{
							EyeStep.inst p55 = CS$<>8__locals1.p;
							p55.data += EyeStep.mnemonics.dr_names[(int)CS$<>8__locals1.p.operands[CS$<>8__locals2.c].append_reg(b5)];
							CS$<>8__locals1.p.operands[CS$<>8__locals2.c].flags |= 262144U;
							break;
						}
						}
						if (CS$<>8__locals2.c < num4 - 1 && num4 > 1)
						{
							EyeStep.inst p56 = CS$<>8__locals1.p;
							p56.data += ",";
						}
						int c = CS$<>8__locals2.c;
						CS$<>8__locals2.c = c + 1;
					}
					break;
				}
			}
			if (CS$<>8__locals1.p.len == 0)
			{
				CS$<>8__locals1.p.len = 1;
				CS$<>8__locals1.p.data = "???";
			}
			return CS$<>8__locals1.p;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000E2C8 File Offset: 0x0000C4C8
		public static List<EyeStep.inst> read(int address, int count)
		{
			int num = address;
			List<EyeStep.inst> list = new List<EyeStep.inst>();
			for (int i = 0; i < count; i++)
			{
				EyeStep.inst inst = EyeStep.read(num);
				list.Add(inst);
				num += inst.len;
			}
			return list;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000E304 File Offset: 0x0000C504
		public static List<EyeStep.inst> read_range(int from, int to)
		{
			int i = from;
			List<EyeStep.inst> list = new List<EyeStep.inst>();
			while (i < to)
			{
				EyeStep.inst inst = EyeStep.read(i);
				list.Add(inst);
				i += inst.len;
			}
			return list;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000E360 File Offset: 0x0000C560
		[CompilerGenerated]
		internal static void <read>g__get_imm8|86_0(byte x, bool constant, ref EyeStep.<>c__DisplayClass86_0 A_2, ref EyeStep.<>c__DisplayClass86_1 A_3)
		{
			string str;
			if (!constant)
			{
				A_2.p.operands[A_3.c].imm8 = x;
				A_2.p.operands[A_3.c].flags |= 16U;
				if (x > 127)
				{
					str = "-" + (256 - (int)A_2.p.operands[A_3.c].imm8).ToString("X2");
				}
				else
				{
					str = "+" + A_2.p.operands[A_3.c].imm8.ToString("X2");
				}
			}
			else
			{
				A_2.p.operands[A_3.c].disp8 = x;
				A_2.p.operands[A_3.c].flags |= 128U;
				str = A_2.p.operands[A_3.c].disp8.ToString("X2");
			}
			EyeStep.inst p = A_2.p;
			p.data += str;
			A_2.p.len++;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000E4C4 File Offset: 0x0000C6C4
		[CompilerGenerated]
		internal static void <read>g__get_imm16|86_1(ushort x, bool constant, ref EyeStep.<>c__DisplayClass86_0 A_2, ref EyeStep.<>c__DisplayClass86_1 A_3)
		{
			string str;
			if (!constant)
			{
				A_2.p.operands[A_3.c].imm16 = x;
				A_2.p.operands[A_3.c].flags |= 32U;
				if (x > 32767)
				{
					str = "-" + (65536 - (int)A_2.p.operands[A_3.c].imm16).ToString("X4");
				}
				else
				{
					str = "+" + A_2.p.operands[A_3.c].imm16.ToString("X4");
				}
			}
			else
			{
				A_2.p.operands[A_3.c].disp16 = x;
				A_2.p.operands[A_3.c].flags |= 256U;
				str = A_2.p.operands[A_3.c].disp16.ToString("X4");
			}
			EyeStep.inst p = A_2.p;
			p.data += str;
			A_2.p.len += 2;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x0000E628 File Offset: 0x0000C828
		[CompilerGenerated]
		internal static void <read>g__get_imm32|86_2(uint x, bool constant, ref EyeStep.<>c__DisplayClass86_0 A_2, ref EyeStep.<>c__DisplayClass86_1 A_3)
		{
			string str;
			if (!constant)
			{
				A_2.p.operands[A_3.c].imm32 = x;
				A_2.p.operands[A_3.c].flags |= 64U;
				if (x > 2147483647U)
				{
					str = "-" + (0U - A_2.p.operands[A_3.c].imm32).ToString("X8");
				}
				else
				{
					str = "+" + A_2.p.operands[A_3.c].imm32.ToString("X8");
				}
			}
			else
			{
				A_2.p.operands[A_3.c].disp32 = x;
				A_2.p.operands[A_3.c].flags |= 512U;
				str = A_2.p.operands[A_3.c].disp32.ToString("X8");
			}
			EyeStep.inst p = A_2.p;
			p.data += str;
			A_2.p.len += 4;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000E788 File Offset: 0x0000C988
		[CompilerGenerated]
		internal static void <read>g__get_sib|86_3(byte imm, ref EyeStep.<>c__DisplayClass86_0 A_1, ref EyeStep.<>c__DisplayClass86_1 A_2)
		{
			byte[] bytes = A_1.p.bytes;
			EyeStep.inst p = A_1.p;
			int num = p.len + 1;
			p.len = num;
			byte b = bytes[num];
			byte reg_type = (byte)EyeStep.longreg(b);
			byte b2 = (byte)EyeStep.finalreg(b);
			if ((b + 32) / 32 % 2 == 0 && b % 32 < 8)
			{
				EyeStep.inst p2 = A_1.p;
				p2.data += EyeStep.mnemonics.r32_names[(int)A_1.p.operands[A_2.c].append_reg(b2)];
				A_1.p.operands[A_2.c].flags |= 4096U;
			}
			else
			{
				if (b2 == 5 && A_1.p.bytes[A_1.p.len - 1] < 64)
				{
					EyeStep.inst p3 = A_1.p;
					p3.data += EyeStep.mnemonics.r32_names[(int)A_1.p.operands[A_2.c].append_reg(reg_type)];
					A_1.p.operands[A_2.c].flags |= 4096U;
				}
				else
				{
					EyeStep.inst p4 = A_1.p;
					p4.data += EyeStep.mnemonics.r32_names[(int)A_1.p.operands[A_2.c].append_reg(b2)];
					EyeStep.inst p5 = A_1.p;
					p5.data += "+";
					EyeStep.inst p6 = A_1.p;
					p6.data += EyeStep.mnemonics.r32_names[(int)A_1.p.operands[A_2.c].append_reg(reg_type)];
					A_1.p.operands[A_2.c].flags |= 4096U;
				}
				if (b / 64 > 0)
				{
					A_1.p.operands[A_2.c].mul = EyeStep.multipliers[(int)(b / 64)];
					string str = A_1.p.operands[A_2.c].mul.ToString("X1");
					EyeStep.inst p7 = A_1.p;
					p7.data += "*";
					EyeStep.inst p8 = A_1.p;
					p8.data += str;
				}
			}
			if (imm == 1)
			{
				EyeStep.<read>g__get_imm8|86_0(A_1.p.bytes[A_1.p.len + 1], false, ref A_1, ref A_2);
				return;
			}
			if (imm == 4 || (imm == 0 && b2 == 5))
			{
				EyeStep.<read>g__get_imm32|86_2(BitConverter.ToUInt32(A_1.p.bytes, A_1.p.len + 1), false, ref A_1, ref A_2);
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000EA54 File Offset: 0x0000CC54
		[CompilerGenerated]
		internal static void <read>g__get_rel8|86_4(byte x, ref EyeStep.<>c__DisplayClass86_0 A_1, ref EyeStep.<>c__DisplayClass86_1 A_2)
		{
			int num = A_1.p.address + A_1.p.len;
			A_1.p.operands[A_2.c].rel8 = x;
			EyeStep.inst p = A_1.p;
			p.data += (num + 1 + (int)A_1.p.operands[A_2.c].rel8).ToString("X8");
			A_1.p.len++;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x0000EAEC File Offset: 0x0000CCEC
		[CompilerGenerated]
		internal static void <read>g__get_rel16|86_5(ushort x, ref EyeStep.<>c__DisplayClass86_0 A_1, ref EyeStep.<>c__DisplayClass86_1 A_2)
		{
			int num = A_1.p.address + A_1.p.len;
			A_1.p.operands[A_2.c].rel16 = x;
			EyeStep.inst p = A_1.p;
			p.data += (num + 2 + (int)A_1.p.operands[A_2.c].rel16).ToString("X8");
			A_1.p.len += 2;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000EB84 File Offset: 0x0000CD84
		[CompilerGenerated]
		internal static void <read>g__get_rel32|86_6(uint x, ref EyeStep.<>c__DisplayClass86_0 A_1, ref EyeStep.<>c__DisplayClass86_1 A_2)
		{
			int num = A_1.p.address + A_1.p.len;
			A_1.p.operands[A_2.c].rel32 = x;
			EyeStep.inst p = A_1.p;
			p.data += ((long)(num + 4) + (long)((ulong)A_1.p.operands[A_2.c].rel32)).ToString("X8");
			A_1.p.len += 4;
		}

		// Token: 0x04000072 RID: 114
		private const int MOD_NOT_FIRST = 255;

		// Token: 0x04000073 RID: 115
		private const int N_X86_OPCODES = 919;

		// Token: 0x04000074 RID: 116
		public static Process current_proc;

		// Token: 0x04000075 RID: 117
		public static int handle;

		// Token: 0x04000076 RID: 118
		public static int base_module;

		// Token: 0x04000077 RID: 119
		public static int base_module_size;

		// Token: 0x04000078 RID: 120
		public static EyeStep.OP_INFO[] OP_TABLE = null;

		// Token: 0x04000079 RID: 121
		public const uint PRE_REPNE = 1U;

		// Token: 0x0400007A RID: 122
		public const uint PRE_REPE = 2U;

		// Token: 0x0400007B RID: 123
		public const uint PRE_66 = 4U;

		// Token: 0x0400007C RID: 124
		public const uint PRE_67 = 8U;

		// Token: 0x0400007D RID: 125
		public const uint PRE_LOCK = 16U;

		// Token: 0x0400007E RID: 126
		public const uint PRE_SEG_CS = 32U;

		// Token: 0x0400007F RID: 127
		public const uint PRE_SEG_SS = 64U;

		// Token: 0x04000080 RID: 128
		public const uint PRE_SEG_DS = 128U;

		// Token: 0x04000081 RID: 129
		public const uint PRE_SEG_ES = 256U;

		// Token: 0x04000082 RID: 130
		public const uint PRE_SEG_FS = 512U;

		// Token: 0x04000083 RID: 131
		public const uint PRE_SEG_GS = 1024U;

		// Token: 0x04000084 RID: 132
		public const byte OP_LOCK = 240;

		// Token: 0x04000085 RID: 133
		public const byte OP_REPNE = 242;

		// Token: 0x04000086 RID: 134
		public const byte OP_REPE = 243;

		// Token: 0x04000087 RID: 135
		public const byte OP_66 = 102;

		// Token: 0x04000088 RID: 136
		public const byte OP_67 = 103;

		// Token: 0x04000089 RID: 137
		public const byte OP_SEG_CS = 46;

		// Token: 0x0400008A RID: 138
		public const byte OP_SEG_SS = 54;

		// Token: 0x0400008B RID: 139
		public const byte OP_SEG_DS = 62;

		// Token: 0x0400008C RID: 140
		public const byte OP_SEG_ES = 38;

		// Token: 0x0400008D RID: 141
		public const byte OP_SEG_FS = 100;

		// Token: 0x0400008E RID: 142
		public const byte OP_SEG_GS = 101;

		// Token: 0x0400008F RID: 143
		public const uint OP_NONE = 0U;

		// Token: 0x04000090 RID: 144
		public const uint OP_SINGLE = 1U;

		// Token: 0x04000091 RID: 145
		public const uint OP_SRC_DEST = 2U;

		// Token: 0x04000092 RID: 146
		public const uint OP_EXTENDED = 4U;

		// Token: 0x04000093 RID: 147
		public const uint OP_IMM8 = 16U;

		// Token: 0x04000094 RID: 148
		public const uint OP_IMM16 = 32U;

		// Token: 0x04000095 RID: 149
		public const uint OP_IMM32 = 64U;

		// Token: 0x04000096 RID: 150
		public const uint OP_DISP8 = 128U;

		// Token: 0x04000097 RID: 151
		public const uint OP_DISP16 = 256U;

		// Token: 0x04000098 RID: 152
		public const uint OP_DISP32 = 512U;

		// Token: 0x04000099 RID: 153
		public const uint OP_R8 = 1024U;

		// Token: 0x0400009A RID: 154
		public const uint OP_R16 = 2048U;

		// Token: 0x0400009B RID: 155
		public const uint OP_R32 = 4096U;

		// Token: 0x0400009C RID: 156
		public const uint OP_R64 = 8192U;

		// Token: 0x0400009D RID: 157
		public const uint OP_XMM = 16384U;

		// Token: 0x0400009E RID: 158
		public const uint OP_MM = 32768U;

		// Token: 0x0400009F RID: 159
		public const uint OP_ST = 65536U;

		// Token: 0x040000A0 RID: 160
		public const uint OP_SREG = 131072U;

		// Token: 0x040000A1 RID: 161
		public const uint OP_DR = 262144U;

		// Token: 0x040000A2 RID: 162
		public const uint OP_CR = 524288U;

		// Token: 0x040000A3 RID: 163
		public const byte R8_AL = 0;

		// Token: 0x040000A4 RID: 164
		public const byte R8_CL = 1;

		// Token: 0x040000A5 RID: 165
		public const byte R8_DL = 2;

		// Token: 0x040000A6 RID: 166
		public const byte R8_BL = 3;

		// Token: 0x040000A7 RID: 167
		public const byte R8_AH = 4;

		// Token: 0x040000A8 RID: 168
		public const byte R8_CH = 5;

		// Token: 0x040000A9 RID: 169
		public const byte R8_DH = 6;

		// Token: 0x040000AA RID: 170
		public const byte R8_BH = 7;

		// Token: 0x040000AB RID: 171
		public const byte R16_AX = 0;

		// Token: 0x040000AC RID: 172
		public const byte R16_CX = 1;

		// Token: 0x040000AD RID: 173
		public const byte R16_DX = 2;

		// Token: 0x040000AE RID: 174
		public const byte R16_BX = 3;

		// Token: 0x040000AF RID: 175
		public const byte R16_SP = 4;

		// Token: 0x040000B0 RID: 176
		public const byte R16_BP = 5;

		// Token: 0x040000B1 RID: 177
		public const byte R16_SI = 6;

		// Token: 0x040000B2 RID: 178
		public const byte R16_DI = 7;

		// Token: 0x040000B3 RID: 179
		public const byte R32_EAX = 0;

		// Token: 0x040000B4 RID: 180
		public const byte R32_ECX = 1;

		// Token: 0x040000B5 RID: 181
		public const byte R32_EDX = 2;

		// Token: 0x040000B6 RID: 182
		public const byte R32_EBX = 3;

		// Token: 0x040000B7 RID: 183
		public const byte R32_ESP = 4;

		// Token: 0x040000B8 RID: 184
		public const byte R32_EBP = 5;

		// Token: 0x040000B9 RID: 185
		public const byte R32_ESI = 6;

		// Token: 0x040000BA RID: 186
		public const byte R32_EDI = 7;

		// Token: 0x040000BB RID: 187
		public static byte[] multipliers = new byte[]
		{
			0,
			2,
			4,
			8
		};

		// Token: 0x0200000C RID: 12
		public class mnemonics
		{
			// Token: 0x04000100 RID: 256
			public static string[] r8_names = new string[]
			{
				"al",
				"cl",
				"dl",
				"bl",
				"ah",
				"ch",
				"dh",
				"bh"
			};

			// Token: 0x04000101 RID: 257
			public static string[] r16_names = new string[]
			{
				"ax",
				"cx",
				"dx",
				"bx",
				"sp",
				"bp",
				"si",
				"di"
			};

			// Token: 0x04000102 RID: 258
			public static string[] r32_names = new string[]
			{
				"eax",
				"ecx",
				"edx",
				"ebx",
				"esp",
				"ebp",
				"esi",
				"edi"
			};

			// Token: 0x04000103 RID: 259
			public static string[] r64_names = new string[]
			{
				"rax",
				"rcx",
				"rdx",
				"rbx",
				"rsp",
				"rbp",
				"rsi",
				"rdi"
			};

			// Token: 0x04000104 RID: 260
			public static string[] xmm_names = new string[]
			{
				"xmm0",
				"xmm1",
				"xmm2",
				"xmm3",
				"xmm4",
				"xmm5",
				"xmm6",
				"xmm7"
			};

			// Token: 0x04000105 RID: 261
			public static string[] mm_names = new string[]
			{
				"mm0",
				"mm1",
				"mm2",
				"mm3",
				"mm4",
				"mm5",
				"mm6",
				"mm7"
			};

			// Token: 0x04000106 RID: 262
			public static string[] sreg_names = new string[]
			{
				"es",
				"cs",
				"ss",
				"ds",
				"fs",
				"gs",
				"hs",
				"is"
			};

			// Token: 0x04000107 RID: 263
			public static string[] dr_names = new string[]
			{
				"dr0",
				"dr1",
				"dr2",
				"dr3",
				"dr4",
				"dr5",
				"dr6",
				"dr7"
			};

			// Token: 0x04000108 RID: 264
			public static string[] cr_names = new string[]
			{
				"cr0",
				"cr1",
				"cr2",
				"cr3",
				"cr4",
				"cr5",
				"cr6",
				"cr7"
			};

			// Token: 0x04000109 RID: 265
			public static string[] st_names = new string[]
			{
				"st(0)",
				"st(1)",
				"st(2)",
				"st(3)",
				"st(4)",
				"st(5)",
				"st(6)",
				"st(7)"
			};
		}

		// Token: 0x0200000D RID: 13
		public struct OP_INFO
		{
			// Token: 0x0600006D RID: 109 RVA: 0x0001173B File Offset: 0x0000F93B
			public OP_INFO(string a, string b, OP_TYPES[] c, string d)
			{
				this.code = a;
				this.opcode_name = b;
				this.operands = c;
				this.description = d;
			}

			// Token: 0x0400010A RID: 266
			public string code;

			// Token: 0x0400010B RID: 267
			public string opcode_name;

			// Token: 0x0400010C RID: 268
			public OP_TYPES[] operands;

			// Token: 0x0400010D RID: 269
			public string description;
		}

		// Token: 0x0200000E RID: 14
		public class operand
		{
			// Token: 0x0600006E RID: 110 RVA: 0x0001175C File Offset: 0x0000F95C
			public operand()
			{
				this.reg = new List<byte>();
				this.rel8 = 0;
				this.rel16 = 0;
				this.rel32 = 0U;
				this.imm8 = 0;
				this.imm16 = 0;
				this.imm32 = 0U;
				this.disp8 = 0;
				this.disp16 = 0;
				this.disp32 = 0U;
				this.mul = 0;
				this.opmode = OP_TYPES.AL;
				this.flags = 0U;
			}

			// Token: 0x0600006F RID: 111 RVA: 0x000117D0 File Offset: 0x0000F9D0
			~operand()
			{
			}

			// Token: 0x06000070 RID: 112 RVA: 0x000117F8 File Offset: 0x0000F9F8
			public byte append_reg(byte reg_type)
			{
				this.reg.Add(reg_type);
				return reg_type;
			}

			// Token: 0x0400010E RID: 270
			public uint flags;

			// Token: 0x0400010F RID: 271
			public OP_TYPES opmode;

			// Token: 0x04000110 RID: 272
			public List<byte> reg;

			// Token: 0x04000111 RID: 273
			public byte mul;

			// Token: 0x04000112 RID: 274
			public byte rel8;

			// Token: 0x04000113 RID: 275
			public ushort rel16;

			// Token: 0x04000114 RID: 276
			public uint rel32;

			// Token: 0x04000115 RID: 277
			public byte imm8;

			// Token: 0x04000116 RID: 278
			public ushort imm16;

			// Token: 0x04000117 RID: 279
			public uint imm32;

			// Token: 0x04000118 RID: 280
			public byte disp8;

			// Token: 0x04000119 RID: 281
			public ushort disp16;

			// Token: 0x0400011A RID: 282
			public uint disp32;
		}

		// Token: 0x0200000F RID: 15
		public class inst
		{
			// Token: 0x06000071 RID: 113 RVA: 0x00011808 File Offset: 0x0000FA08
			public inst()
			{
				this.bytes = new byte[16];
				this.operands = new List<EyeStep.operand>();
				this.operands.Add(new EyeStep.operand());
				this.operands.Add(new EyeStep.operand());
				this.operands.Add(new EyeStep.operand());
				this.operands.Add(new EyeStep.operand());
				this.address = 0;
				this.flags = 0U;
				this.len = 0;
			}

			// Token: 0x06000072 RID: 114 RVA: 0x00011888 File Offset: 0x0000FA88
			~inst()
			{
				this.operands.Clear();
			}

			// Token: 0x06000073 RID: 115 RVA: 0x000118BC File Offset: 0x0000FABC
			public EyeStep.operand source()
			{
				if (this.operands.Count <= 0)
				{
					return new EyeStep.operand();
				}
				return this.operands[0];
			}

			// Token: 0x06000074 RID: 116 RVA: 0x000118DE File Offset: 0x0000FADE
			public EyeStep.operand destination()
			{
				if (this.operands.Count <= 1)
				{
					return new EyeStep.operand();
				}
				return this.operands[1];
			}

			// Token: 0x0400011B RID: 283
			public string data;

			// Token: 0x0400011C RID: 284
			public EyeStep.OP_INFO info;

			// Token: 0x0400011D RID: 285
			public uint flags;

			// Token: 0x0400011E RID: 286
			public int address;

			// Token: 0x0400011F RID: 287
			public byte[] bytes;

			// Token: 0x04000120 RID: 288
			public int len;

			// Token: 0x04000121 RID: 289
			public List<EyeStep.operand> operands;
		}
	}
}
