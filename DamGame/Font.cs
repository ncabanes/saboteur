/**
 * Font.cs - To hide SDL TTF font handling
 * 
 * Changes:
 * 0.01, 24-jul-2013: Initial version, based on SdlMuncher 0.02
 */

using System;
using Tao.Sdl;

class Font
{
    private IntPtr internalPointer;

    public Font(string fileName, short sizePoints)
    {
        Load(fileName, sizePoints);
    }

    public void Load(string fileName, short sizePoints)
    {
        internalPointer = SdlTtf.TTF_OpenFont(fileName, sizePoints);
        if (internalPointer == IntPtr.Zero)
            SdlHardware.FatalError("Font not found: " + fileName);
    }

    public IntPtr GetPointer()
    {
        return internalPointer;
    }
}
