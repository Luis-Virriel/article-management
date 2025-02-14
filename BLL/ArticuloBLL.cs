using DAL;
using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BLL
{
    public class ArticuloBLL
    {
        private ArticuloDAL articuloDAL = new ArticuloDAL();

        public List<Articulo> ObtenerArticulos()
        {
            List<Articulo> listaArticulos = new List<Articulo>();

            try
            {
                articuloDAL.setearConsulta(
                    "SELECT A.Id AS ArticuloId, A.Codigo, A.Nombre, A.Descripcion AS ArticuloDescripcion, " +
                    "M.Id AS MarcaId, M.Descripcion AS MarcaDescripcion, " +
                    "C.Id AS CategoriaId, C.Descripcion AS CategoriaDescripcion, " +
                    "A.ImagenUrl, A.Precio " +
                    "FROM Articulos A " +
                    "INNER JOIN Marcas M ON A.IdMarca = M.Id " +
                    "INNER JOIN Categorias C ON A.IdCategoria = C.Id");

                articuloDAL.ejecutarLectura();

                while (articuloDAL.Lector.Read())
                {
                    Articulo articulo = new Articulo
                    {
                        Id = Convert.ToInt32(articuloDAL.Lector["ArticuloId"]),
                        Codigo = articuloDAL.Lector["Codigo"].ToString(),
                        Nombre = articuloDAL.Lector["Nombre"].ToString(),
                        Descripcion = articuloDAL.Lector["ArticuloDescripcion"].ToString(),
                        ImagenUrl = articuloDAL.Lector["ImagenUrl"] != DBNull.Value ? articuloDAL.Lector["ImagenUrl"].ToString() : "https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png",
                        Precio = Convert.ToDecimal(articuloDAL.Lector["Precio"]),
                        Marca = new Marca
                        {
                            Id = Convert.ToInt32(articuloDAL.Lector["MarcaId"]),
                            Descripcion = articuloDAL.Lector["MarcaDescripcion"].ToString()
                        },
                        Categoria = new Categoria
                        {
                            Id = Convert.ToInt32(articuloDAL.Lector["CategoriaId"]),
                            Descripcion = articuloDAL.Lector["CategoriaDescripcion"].ToString()
                        }
                    };

                    listaArticulos.Add(articulo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los artículos: " + ex.Message);
            }
            finally
            {
                articuloDAL.cerrarConexion();
            }

            return listaArticulos;
        }
    }
}
