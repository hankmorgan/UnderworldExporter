#ifndef Conversations_h
#define Conversations_h

#define	cnv_NOP	0
#define	cnv_OPADD	1
#define	cnv_OPMUL	2
#define	cnv_OPSUB	3
#define	cnv_OPDIV	4
#define	cnv_OPMOD	5
#define	cnv_OPOR	6
#define	cnv_OPAND	7
#define	cnv_OPNOT	8
#define	cnv_TSTGT	9
#define	cnv_TSTGE	0A
#define	cnv_TSTLT	0B
#define	cnv_TSTLE	0C
#define	cnv_TSTEQ	0D
#define	cnv_TSTNE	0E
#define	cnv_JMP	0F
#define	cnv_BEQ	10
#define	cnv_BNE	11
#define	cnv_BRA	12
#define	cnv_CALL	13
#define	cnv_CALLI	14
#define	cnv_RET	15
#define	cnv_PUSHI	16
#define	cnv_PUSHI_EFF	17
#define	cnv_POP	18
#define	cnv_SWAP	19
#define	cnv_PUSHBP	1A
#define	cnv_POPBP	1B
#define	cnv_SPTOBP	1C
#define	cnv_BPTOSP	1D
#define	cnv_ADDSP	1E
#define	cnv_FETCHM	1F
#define	cnv_STO	20
#define	cnv_OFFSET	21
#define	cnv_START	22
#define	cnv_SAVE_REG	23
#define	cnv_PUSH_REG	24
#define	cnv_STRCMP	25
#define	cnv_EXIT_OP	26
#define	cnv_SAY_OP	27
#define	cnv_RESPOND_OP	28
#define	cnv_OPNEG	29






	void ExtractConversations(int game);
#endif /* Conversations_h */