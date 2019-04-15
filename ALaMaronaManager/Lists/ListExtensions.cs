using ALaMarona.Core.Businesses;
using ALaMarona.Domain.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ALaMaronaManager.Lists
{
    public static class ListExtensions
    {
        public static IEnumerable<ListItem<long>> ToComboList(this IEnumerable<Cliente> clientes)
        {
            return clientes.Select(x =>
            {
                return new ListItem<long>()
                {
                    Id = x.Id,
                    Nombre = ClienteBusiness.GetNombreCliente(x)
                };
            });
        }

        public static IEnumerable<ListItem<long>> ToComboList(this IEnumerable<Pais> paises)
        {
            return paises.Select(x =>
            {
                return new ListItem<long>()
                {
                    Id = x.Id,
                    Nombre = x.Nombre
                };
            });
        }

        public static IEnumerable<ListItem<long>> ToComboList(this IEnumerable<Provincia> provincias)
        {
            return provincias.Select(x =>
            {
                return new ListItem<long>()
                {
                    Id = x.Id,
                    Nombre = x.Nombre
                };
            });
        }

        public static IEnumerable<ListItem<long>> ToComboList(this IEnumerable<Localidad> localidades)
        {
            return localidades.Select(x =>
            {
                return new ListItem<long>()
                {
                    Id = x.Id,
                    Nombre = x.Nombre
                };
            });
        }

        public static void FillDataTableFromList<TId>(this DataTable dataTable, IEnumerable<ListItem<TId>> items)
        {
            dataTable.Rows.Clear();
            foreach (var item in items)
            {
                DataRow row = dataTable.NewRow();
                row["Nombre"] = item.Nombre;
                row["Id"] = item.Id;
                dataTable.Rows.Add(row);
            }
        }
    }
}