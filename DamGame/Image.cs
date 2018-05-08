/**
 * Image.cs - To hide SDL image handling
 * 
 * Changes:
 * 0.01, 24-jul-2013: Initial version, based on SdlMuncher 0.02
 */

using System;
using Tao.Sdl;

class Image
{
    private IntPtr internalPointer;

    public Image(string fileName)  // Constructor
    {
        Load(fileName);
    }

    public void Load(string fileName)
    {
        internalPointer = SdlImage.IMG_Load(fileName);
        if (internalPointer == IntPtr.Zero)
            SdlHardware.FatalError("Image not found: " + fileName);
    }

    public IntPtr GetPointer()
    {
        return internalPointer;
    }
}
