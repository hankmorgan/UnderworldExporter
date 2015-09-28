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
#define	cnv_TSTGE	10
#define	cnv_TSTLT	11
#define	cnv_TSTLE	12
#define	cnv_TSTEQ	13
#define	cnv_TSTNE	14
#define	cnv_JMP	15
#define	cnv_BEQ	16
#define	cnv_BNE	17
#define	cnv_BRA	18
#define	cnv_CALL	19
#define	cnv_CALLI	20
#define	cnv_RET	21
#define	cnv_PUSHI	22
#define	cnv_PUSHI_EFF	23
#define	cnv_POP	24
#define	cnv_SWAP	25
#define	cnv_PUSHBP	26
#define	cnv_POPBP	27
#define	cnv_SPTOBP	28
#define	cnv_BPTOSP	29
#define	cnv_ADDSP	30
#define	cnv_FETCHM	31
#define	cnv_STO	32
#define	cnv_OFFSET	33
#define	cnv_START	34
#define	cnv_SAVE_REG	35
#define	cnv_PUSH_REG	36
#define	cnv_STRCMP	37
#define	cnv_EXIT_OP	38
#define	cnv_SAY_OP	39
#define	cnv_RESPOND_OP	40
#define	cnv_OPNEG	41






	void ExtractConversations(int game);
#endif /* Conversations_h */