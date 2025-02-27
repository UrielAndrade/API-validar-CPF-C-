using System.Text.RegularExpressions;

namespace ValidarCPF.Routes
{
    public static class CpfRoute
    {
        // O THIS referencia que é um método de extensão!
        public static void CpfRoutes(this WebApplication app)
        {
            app.MapPost("/CPFsend", (string CPF) =>
            {
                CPF = formatarCPF(CPF);
                bool ExibirStatus = VerificarCPF(CPF);

                if (ExibirStatus) return "CPF valido";
                else return "CPF invalido";
            });
        }

        static bool VerificarCPF(string CPF)
        {
            if (CPF.Length != 11) return false; // CPF deve ter 11 dígitos

            int[] multiplicadores1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadores2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int somaMultiplicacao = 0;
            for (int i = 0; i < 9; i++)
            {
                // (CPF[i] - '0')  devido vir em CHAR
                somaMultiplicacao += (CPF[i] - '0') * multiplicadores1[i];
            }

            int digitoVerificador1 = (somaMultiplicacao * 10) % 11;
            if (digitoVerificador1 == 10) digitoVerificador1 = 0;

            //Reultilizar a variavel
            somaMultiplicacao = 0;
            for (int i = 0; i < 10; i++)
            {
                somaMultiplicacao += (CPF[i] - '0') * multiplicadores2[i];
            }

            int digitoVerificador2 = (somaMultiplicacao * 10) % 11;
            if (digitoVerificador2 == 10) digitoVerificador2 = 0;

            bool primeiroDigitoValido = (CPF[9] - '0') == digitoVerificador1;
            bool segundoDigitoValido = (CPF[10] - '0') == digitoVerificador2;

            if (primeiroDigitoValido && segundoDigitoValido)
                return true;
            else
                return false;
        }
        static string formatarCPF(string CPF)
        {
            CPF = Regex.Replace(CPF, "[.-]", ""); // Usei regex pois lembrei sobre o curso ele fez algo parecido;
            return CPF;
        }

    }

}