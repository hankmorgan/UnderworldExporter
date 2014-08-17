#ifndef materials_h
#define materials_h

void BuildXDataFile(int game);
void BuildSndShaderFiles();
void BuildSHOCKMtrFiles(int MtrType);
void BuildGuiFiles();
void ExportModelFormat();
void BuildWORDSXData(int game);
void BuildUWXData(int game, int TargetBlock);
void BuildUWMtrFiles(int game, int mtrType);
void BuildParticles(int game);
#endif /*materials_h*/