using System;
using System.IO;

namespace ProjetoNave
{
    public class ManipulaArquivo
    {
        

    private string arquivo;
        public ManipulaArquivo(string arquivo)
        {
            this.arquivo = arquivo;
        }

        public void EscreverPontuacao(int pontuacao)
        {
            using (StreamWriter sw = new StreamWriter(arquivo, true))
            {
                sw.Write(pontuacao);
                sw.Close();
            }
        }

        public int LerPontuacao()
        {
            int pontuacao = 0;
            if (File.Exists(arquivo))
            {
                using (StreamReader sr = new StreamReader(arquivo))
                {
                    pontuacao = Convert.ToInt32(sr.ReadToEnd());
                    sr.Close();
                }
                File.Delete(arquivo);
            }
            
            return pontuacao;
        }
    }
}
