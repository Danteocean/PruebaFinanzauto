using PruebaDanielMolina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace PruebaDanielMolina.Business
{
    public class Calculation
    {
        public Transaccion transaccion;
        public Calculation(Transaccion transaccion)
        {
            this.transaccion = transaccion;
        }

        public Transaccion GetAccounts()
        {
            Transaccion trans = new Transaccion();
            AplicationDbContext context = new AplicationDbContext();
            List<Transaccion> listTransaccions = new List<Transaccion>();
            listTransaccions = context.Transaccions.Where(n => n.IdCliente == transaccion.IdCliente).ToList();
            if (listTransaccions.Count == 0)
            {
                listTransaccions = context.Transaccions.ToList();
                if (transaccion.IdCuenta == null)
                {

                    listTransaccions = context.Transaccions.ToList();
                    if (listTransaccions.Count == 0)
                    {
                        trans.IdCuenta = 1;
                        trans.IdTransaccion = transaccion.IdTransaccion;
                        trans.Saldo = transaccion.Saldo;
                        trans.IdCliente = transaccion.IdCliente;
                        trans.Fecha = transaccion.Fecha;
                        trans.TipoTransaccion = transaccion.TipoTransaccion;
                        return trans;
                    }
                    trans.IdCuenta = listTransaccions.Max(x => x.IdCuenta) + 1;
                    trans.IdTransaccion = transaccion.IdTransaccion;
                    trans.Saldo = transaccion.Saldo;
                    trans.IdCliente = transaccion.IdCliente;
                    trans.Fecha = transaccion.Fecha;
                    trans.TipoTransaccion = transaccion.TipoTransaccion;
                    return trans;
                }
                transaccion.IdCuenta = listTransaccions.Max(x => x.IdCuenta) + 1;

                return transaccion;
            }
            if (transaccion.IdCuenta == null)
            {
                listTransaccions = context.Transaccions.ToList();
                trans.IdCuenta = listTransaccions.Max(x => x.IdCuenta) + 1;
                trans.IdTransaccion = transaccion.IdTransaccion;
                trans.Saldo = transaccion.Saldo;
                trans.IdCliente = transaccion.IdCliente;
                trans.TipoTransaccion = transaccion.TipoTransaccion;
                trans.Fecha = transaccion.Fecha;
                return trans;
            }

            trans = listTransaccions.Last();

            transaccion.IdCliente = trans.IdCliente;
            transaccion.IdCuenta = trans.IdCuenta;
            if (transaccion.TipoTransaccion == 4)
            {
                transaccion.TipoTransaccion = 1;
            }

            if (transaccion.TipoTransaccion == 1)
            {

                transaccion.Saldo = Convert.ToDecimal(trans.Saldo) + transaccion.Saldo;
            }
            else
            {
                transaccion.Saldo = Convert.ToDecimal(trans.Saldo) - transaccion.Saldo;
                if (transaccion.Saldo < 0)
                {
                    transaccion.Saldo = Convert.ToDecimal(trans.Saldo);
                    transaccion.TipoTransaccion = 3;
                }
            }


            return transaccion;
        }
    }
}
