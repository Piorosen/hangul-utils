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

            for (int i = 0; i < key.Length; i++)
            {
                int size = 0;

                for (int v = 0; v < search.Length; v++)
                {
                    if ((key[i + v] & search[v]) == search[v])
                    {
                        size++;
                    }else
                    {
                        break;
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