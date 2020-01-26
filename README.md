# pkhex-save-converter-plugin
pkhex plugin to convert ds saves between raw and desmume saves

# usage
drag SaveConverter.dll to pkhex.exe../plugins and run pkhex.

click the option in the tools menu, and convert. if the save file is in pkhex already, it'll still be loaded as the original file name so be sure to overwrite the proper save.

for the standalone executable, drag and drop a .sav or .dsv file onto the program, and it will replace the file with the converted one.

# building
the pkhex plugin requires you to create a class library project with pkhex.core as a reference, and it's pretty basic from there.

the standalone is literally a copy + paste job, no special requirements. i built it as a console application, but you can use whatever you want.

# smile
:)
