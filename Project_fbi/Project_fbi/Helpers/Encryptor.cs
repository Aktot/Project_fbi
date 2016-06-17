using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
namespace Project_fbi.Helpers
{
    public class Encryptor
    {
            public enum State
            {
                Hiding,
                Filling_With_Zeros
            };

        
            public static string extractText(Bitmap bmp)
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

            public static int reverseBits(int n)
            {
                int result = 0;

                for (int i = 0; i < 8; i++)
                {
                    result = result * 2 + n % 2;

                    n /= 2;
                }

                return result;
            }
        }
    }