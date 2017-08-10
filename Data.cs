using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeonardoAlmeidaFraga
{
    public class Data
    {
        //Recebe uma data em string no formato (dd/mm/yyyy hh:mm)
        //Recebe um operador (+ ou -)
        //Recebe uma quantidade de minutos

        public string ChangeDate(string date, char op, long value)
        {
            string retorno = string.Empty;

            //Valida o operador
            if ((op != '+') && (op != '-'))
                return retorno = "Operador inválido";

            //Valida a data
            bool dataValida = ValidaData(date);
            if (dataValida == false)
                return retorno = "Data inválida";

            //Busco a quantidade de dias no mes
            int quantidadeDiasMes = RetornaDiasNoMes(date.Substring(3, 2));

            int diaInicial = Convert.ToInt32(date.Substring(0, 2));
            int mesInicial = Convert.ToInt32(date.Substring(3, 2));
            int anoInicial = Convert.ToInt32(date.Substring(6, 4));
            int horaInicial = Convert.ToInt32(date.Substring(11, 2));
            int minutoInicial = Convert.ToInt32(date.Substring(14, 2));

            string diaRetorno = string.Empty;
            string mesRetorno = string.Empty;
            string horaRetorno = string.Empty;
            string minutoRetorno = string.Empty;

            

            if (op == '+')
            {
                while (value > 0)
                {
                    minutoInicial++;

                    if (minutoInicial >= 60)//Se os minutos atingirem uma hora
                    {
                        minutoInicial = 0;
                        horaInicial++;

                        if (horaInicial >= 24)//Se as horas atingirem um dia
                        {
                            horaInicial = 0;
                            diaInicial++;

                            if (diaInicial > quantidadeDiasMes)//Se a quantidade de dias for maior que os dias que o mes possui
                            {

                                diaInicial = 1;
                                mesInicial++;

                                //Adiciono um zero a esquerda se o mes for menor que 10
                                string novoMes = string.Empty;

                                if (mesInicial < 10)
                                    novoMes = "0" + mesInicial.ToString();

                                else if (mesInicial == 13)
                                    novoMes = "01";

                                else
                                    novoMes = mesInicial.ToString();

                                quantidadeDiasMes = RetornaDiasNoMes(novoMes);

                                if (mesInicial > 12)
                                {

                                    mesInicial = 1;
                                    anoInicial++;
                                }
                            }
                        }
                    }


                    value--;
                }
            }
            else 
            {
                while (value > 0)
                {
                    minutoInicial--;

                    if (minutoInicial < 0)
                    {
                        minutoInicial = 59;
                        horaInicial--;

                        if (horaInicial < 0)
                        {
                            horaInicial = 23;
                            diaInicial--;

                            if (diaInicial < 1)
                            {

                                mesInicial--;

                                //Adiciono um zero a esquerda se o mes for menor que 10
                                string novoMes = string.Empty;

                                if ((mesInicial > 1) && (mesInicial < 10))
                                    novoMes = "0" + mesInicial.ToString();

                                else if (mesInicial == 0)
                                    novoMes = "12";

                                else
                                    novoMes = mesInicial.ToString();

                                quantidadeDiasMes = RetornaDiasNoMes(novoMes);

                                diaInicial = quantidadeDiasMes;




                                if (mesInicial < 1)
                                {
                                    mesInicial = 12;
                                    anoInicial--;
                                }
                            }
                        }
                    }


                    value--;
                }
            }

            minutoRetorno = CompletaZeroEsquerda(minutoInicial);
            horaRetorno = CompletaZeroEsquerda(horaInicial);
            diaRetorno = CompletaZeroEsquerda(diaInicial);
            mesRetorno = CompletaZeroEsquerda(mesInicial);

            retorno = diaRetorno + "/" + mesRetorno + "/" + anoInicial + " " + horaRetorno + ":" + minutoRetorno;

            return retorno;
        }

        private int RetornaDiasNoMes(string mes)
        {
            int diasNoMes = 0;

            switch (mes)
            {
                case "01":
                    diasNoMes = 31;
                    break;
                case "02":
                    diasNoMes = 28;//Considero sempre fevereiro com 28 dias
                    break;
                case "03":
                    diasNoMes = 31;
                    break;
                case "04":
                    diasNoMes = 30;
                    break;
                case "05":
                    diasNoMes = 31;
                    break;
                case "06":
                    diasNoMes = 30;
                    break;
                case "07":
                    diasNoMes = 31;
                    break;
                case "08":
                    diasNoMes = 31;
                    break;
                case "09":
                    diasNoMes = 30;
                    break;
                case "10":
                    diasNoMes = 31;
                    break;
                case "11":
                    diasNoMes = 30;
                    break;
                case "12":
                    diasNoMes = 31;
                    break;
            }



            return diasNoMes;
        }

        private bool ValidaData(string date)
        {
            int dia = 0;
            int mes = 0;
            int ano = 0;
            int hora = 0;
            int minuto = 0;


            dia = Convert.ToInt32(date.Substring(0, 2));
            if ((dia <= 0) || (dia > 31))
                return false;


            mes = Convert.ToInt32(date.Substring(3, 2));
            if ((mes <= 0) || (mes > 12))
                return false;


            ano = Convert.ToInt32(date.Substring(6, 4));
            if ((ano <= 0) || (ano > 9999))
                return false;

            
            hora = Convert.ToInt32(date.Substring(11, 2));
            if (hora > 23)
                return false;


            minuto = Convert.ToInt32(date.Substring(14, 2));
            if (minuto > 59)
                return false;

            return true;
        }

        private string CompletaZeroEsquerda(int numero)
        {
            string numeroRetorno = string.Empty;

            if (numero < 10)
                numeroRetorno = "0" + numero;

            else
                numeroRetorno = numero.ToString();
            
            return numeroRetorno;
        }
    }
}

