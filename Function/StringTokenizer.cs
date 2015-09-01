namespace Function
{
    using System;
    using System.Collections;

    public class StringTokenizer
    {
        private int CurrIndex;
        private int NumTokens;
        private string StrDelimiter;
        private string StrSource;
        private ArrayList tokens;

        public StringTokenizer() : this("", "")
        {
        }

        public StringTokenizer(string source) : this(source, "")
        {
        }

        public StringTokenizer(string source, char[] delimiter) : this(source, new string(delimiter))
        {
        }

        public StringTokenizer(string source, string delimiter)
        {
            this.tokens = new ArrayList(10);
            this.StrSource = source;
            this.StrDelimiter = delimiter;
            if (delimiter.Length == 0)
            {
                this.StrDelimiter = " ";
            }
            this.Tokenize();
        }

        public int CountTokens()
        {
            return this.tokens.Count;
        }

        public bool HasMoreTokens()
        {
            return (this.CurrIndex <= (this.tokens.Count - 1));
        }

        public void NewDelim(string newDel)
        {
            if (newDel.Length == 0)
            {
                this.StrDelimiter = " ";
            }
            else
            {
                this.StrDelimiter = newDel;
            }
            this.Tokenize();
        }

        public void NewDelim(char[] newDel)
        {
            string str = new string(newDel);
            if (str.Length == 0)
            {
                this.StrDelimiter = " ";
            }
            else
            {
                this.StrDelimiter = str;
            }
            this.Tokenize();
        }

        public void NewSource(string newSrc)
        {
            this.StrSource = newSrc;
            this.Tokenize();
        }

        public string NextToken()
        {
            string str = "";
            if (this.CurrIndex <= (this.tokens.Count - 1))
            {
                str = (string) this.tokens[this.CurrIndex];
                this.CurrIndex++;
                return str;
            }
            return null;
        }

        private void Tokenize()
        {
            string strSource = this.StrSource;
            string str2 = "";
            this.NumTokens = 0;
            this.tokens.Clear();
            this.CurrIndex = 0;
            if ((strSource.IndexOf(this.StrDelimiter) < 0) && (strSource.Length > 0))
            {
                this.NumTokens = 1;
                this.CurrIndex = 0;
                this.tokens.Add(strSource);
                this.tokens.TrimToSize();
                strSource = "";
            }
            else if ((strSource.IndexOf(this.StrDelimiter) < 0) && (strSource.Length <= 0))
            {
                this.NumTokens = 0;
                this.CurrIndex = 0;
                this.tokens.TrimToSize();
            }
            while (strSource.IndexOf(this.StrDelimiter) >= 0)
            {
                if (strSource.IndexOf(this.StrDelimiter) == 0)
                {
                    if (strSource.Length > this.StrDelimiter.Length)
                    {
                        strSource = strSource.Substring(this.StrDelimiter.Length);
                    }
                    else
                    {
                        strSource = "";
                    }
                }
                else
                {
                    str2 = strSource.Substring(0, strSource.IndexOf(this.StrDelimiter));
                    this.tokens.Add(str2);
                    if (strSource.Length > (this.StrDelimiter.Length + str2.Length))
                    {
                        strSource = strSource.Substring(this.StrDelimiter.Length + str2.Length);
                    }
                    else
                    {
                        strSource = "";
                    }
                }
            }
            if (strSource.Length > 0)
            {
                this.tokens.Add(strSource);
            }
            this.tokens.TrimToSize();
            this.NumTokens = this.tokens.Count;
        }

        public string Delim
        {
            get
            {
                return this.StrDelimiter;
            }
        }

        public string Source
        {
            get
            {
                return this.StrSource;
            }
        }
    }
}

