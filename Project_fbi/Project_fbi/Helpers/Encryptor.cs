using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
namespace Project_fbi.Helpers
{
    public class Encryptor
    {          
        public int[] ClearLeastSugnificantBitColor(Color color)
        {
            int[] resColor = new int[3];
            resColor[0] = color.R - color.R % 2;
            resColor[1] = color.G - color.G % 2;
            resColor[2] = color.B - color.B % 2;
            return resColor;
        }
        public Bitmap Encrypt(string text, Bitmap bmp)
        {
            bool isEncrypting = true;

            int charIndex = 0;

            int charValue = 0;

            long pixelElementIndex = 0;

            int zeros = 0;

            int R = 0, G = 0, B = 0;

            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    Color pixel = bmp.GetPixel(j, i);

                    int[] clearValue = ClearLeastSugnificantBitColor(pixel);

                    R = clearValue[0];
                    G = clearValue[1];
                    B = clearValue[2];

                    for (int n = 0; n < 3; n++)
                    {
                        if (pixelElementIndex % 8 == 0)
                        {
                            if (!isEncrypting && zeros == 8)
                            {
                                if ((pixelElementIndex - 1) % 3 < 2)
                                {
                                    bmp.SetPixel(j, i, Color.FromArgb(R, G, B));
                                }
                                return bmp;
                            }

                            if (charIndex >= text.Length)
                            {
                                isEncrypting = false;
                            }
                            else
                            {
                                charValue = text[charIndex++];
                            }
                        }

                        switch (pixelElementIndex % 3)
                        {
                            case 0:
                                {
                                    if (isEncrypting)
                                    {
                                        R += charValue % 2;
                                        charValue /= 2;
                                    }
                                }
                                break;
                            case 1:
                                {
                                    if (isEncrypting)
                                    {
                                        G += charValue % 2;
                                        charValue /= 2;
                                    }
                                }
                                break;
                            case 2:
                                {
                                    if (isEncrypting)
                                    {
                                        B += charValue % 2;
                                        charValue /= 2;
                                    }

                                    bmp.SetPixel(j, i, Color.FromArgb(R, G, B));
                                }
                                break;
                        }

                        pixelElementIndex++;

                        if (!isEncrypting)
                        {
                            zeros++;
                        }
                    }
                }
            }

            return bmp;
        }
        
        public string Decrypt(Bitmap bmp)
            {
                int colorUnitIndex = 0;
                int charValue = 0;

               string extractedText = String.Empty;
            
                for (int i = 0; i < bmp.Height; i++)
                {
                    for (int j = 0; j < bmp.Width; j++)
                    {
                        Color pixel = bmp.GetPixel(j, i);

                        for (int n = 0; n < 3; n++)
                        {
                            switch (colorUnitIndex % 3)
                            {
                                case 0:
                                    {
                                        charValue = charValue * 2 + pixel.R % 2;
                                    }
                                    break;
                                case 1:
                                    {
                                        charValue = charValue * 2 + pixel.G % 2;
                                    }
                                    break;
                                case 2:
                                    {
                                        charValue = charValue * 2 + pixel.B % 2;
                                    }
                                    break;
                            }

                            colorUnitIndex++;

                            if (colorUnitIndex % 8 == 0)
                            {
                                charValue = reverseBits(charValue);
                                if (charValue == 0)
                                {
                                    return extractedText;
                                }
                                char c = (char)charValue;
                            
                                extractedText += c.ToString();
                            }
                        }
                    }
                }

                return extractedText;
            }

            public int reverseBits(int n)
            {
                int result = 0;

                for (int i = 0; i < 8; i++)
                {
                    result = result * 2 + n % 2;

                    n /= 2;
                }

                return result;
            }
        public bool compare(Bitmap bmp1, Bitmap bmp2)
        {
            bool equals = true;
            bool flag = true;  
            
            if (bmp1.Size == bmp2.Size)
            {
                for (int x = 0; x < bmp1.Width; ++x)
                {
                    for (int y = 0; y < bmp1.Height; ++y)
                    {
                        if (bmp1.GetPixel(x, y) != bmp2.GetPixel(x, y))
                        {
                            equals = false;
                            flag = false;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        break;
                    }
                }
            }
            else
            {
                equals = false;
            }
            return equals;
        }

    }
    }