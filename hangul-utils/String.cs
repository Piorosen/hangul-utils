using System;

namespace hangul_utils
{
    public static class ExtensionString
    {
        private const string first = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";
        //private const string second = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ";
        //private const string third = " ㄱㄲㄳㄴㄵㄶㄷㄹㄺㄻㄼㄽㄾㄿㅀㅁㅂㅄㅅㅆㅇㅈㅊㅋㅌㅍㅎ";
        private const ushort startConsonants = 0x3131;
        private const ushort lastConsonants = 0x314E;

        private const ushort startHangul = 0xAC00;
        private const ushort lastHangul = 0xD7A3;

        public static ushort[] KoreaConvert(string value)
        {
            ushort[] data = new ushort[value.Length];

            for (int i = 0; i < value.Length; i++)
            {
                int calc = Convert.ToUInt16(value[i]);

                if (startConsonants <= calc && calc <= lastConsonants)
                {
                    data[i] = (ushort)(first.IndexOf(value[i]) << 10);
                    data[i] |= (ushort)(1 << 15);
                    
                }
                else if (startHangul <= calc && calc <= lastHangul)
                {
                    calc -= startHangul;
                    int ChoSung, JungSung, JongSung; // 초성,중성,종성의 인덱스


                    JongSung = calc % 28; // 종성 코드 분리
                    calc = (calc - JongSung) / 28;

                    JungSung = calc % 21; // 중성 코드 분리
                    calc = (calc - JungSung) / 21;

                    ChoSung = calc; // 남는 게 자동으로 초성이 됩니다.


                    data[i] = (ushort)(ChoSung << 10 | JungSung << 5 | JongSung);
                }else
                {
                    data[i] = (ushort)calc;
                }
            }
            return data;
        }

        public static bool KoreaContains(this string rhs, string korean)
        {
            var key = KoreaConvert(rhs);
            var search = KoreaConvert(korean);

            for (int i = 0; i < key.Length - search.Length + 1; i++)
            {
                int size = 0;

                for (int v = 0; v < search.Length; v++)
                {
                    // 검색에 자음 있음.
                    if ((search[v] & (1 << 15)) == (1 << 15))
                    {
                        search[v] &= (0b0111_1111_1111_1111);
                        if (key[i + v] >> 10 == search[v] >> 10)
                        {
                            size++;
                        }else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if ((key[i + v] & search[v]) == search[v])
                        {
                            size++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (size == search.Length)
                {
                    return true;
                }
            }

            return false;
        }
    }
}