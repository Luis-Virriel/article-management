﻿using DAL;
using Dominio;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

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
        
        public void agregar(Articulo articuloNuevo)
        {
            ArticuloDAL datos = new ArticuloDAL();
            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, ImagenUrl, IdMarca, IdCategoria, Precio) " +
                              "VALUES (@Codigo, @Nombre, @Descripcion, @ImagenUrl, @IdMarca, @IdCategoria, @Precio)");
                datos.setearParametro("@Codigo", articuloNuevo.Codigo);
                datos.setearParametro("@Nombre", articuloNuevo.Nombre);
                datos.setearParametro("@Descripcion", articuloNuevo.Descripcion);
                datos.setearParametro("@ImagenUrl", articuloNuevo.ImagenUrl ?? (object)DBNull.Value); 
                datos.setearParametro("@IdMarca", articuloNuevo.Marca.Id);
                datos.setearParametro("@IdCategoria", articuloNuevo.Categoria.Id);
                datos.setearParametro("@Precio", articuloNuevo.Precio);

                datos.ejecutarAccion();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void modificar(Articulo articulo)
        {
            ArticuloDAL datos = new ArticuloDAL();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @Codigo, Nombre = @nombre, Descripcion = @descripcion, ImagenUrl = @img, IdMarca = @IdMarca, IdCategoria = @idCategoria, Precio = @precio Where Id = @id");
                datos.setearParametro("@Codigo", articulo.Codigo);

                datos.setearParametro("@nombre", articulo.Nombre);
 
                datos.setearParametro("@descripcion", articulo.Descripcion);

                datos.setearParametro("@img", articulo.ImagenUrl);

                datos.setearParametro("@idMarca", articulo.Marca.Id);

                datos.setearParametro("@idCategoria", articulo.Categoria.Id);

                datos.setearParametro("@precio", articulo.Precio);

                datos.setearParametro("@id", articulo.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void eliminar(int idArticulo)
        {
            ArticuloDAL datos = new ArticuloDAL();
            try
            {
                datos.setearConsulta("DELETE FROM ARTICULOS WHERE Id = @id");
                datos.setearParametro("@id", idArticulo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el artículo: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public List<Marca> ObtenerMarcas()
        {
            List<Marca> listaMarcas = new List<Marca>();

            try
            {
                articuloDAL.setearConsulta("SELECT Id, Descripcion FROM Marcas");

                articuloDAL.ejecutarLectura();

                while (articuloDAL.Lector.Read())
                {
                    Marca marca = new Marca
                    {
                        Id = Convert.ToInt32(articuloDAL.Lector["Id"]),
                        Descripcion = articuloDAL.Lector["Descripcion"].ToString()
                    };

                    listaMarcas.Add(marca);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las marcas: " + ex.Message);
            }
            finally
            {
                articuloDAL.cerrarConexion();
            }

            return listaMarcas;
        }
        public List<Categoria> ObtenerCategorias()
        {
            List<Categoria> listaCategorias = new List<Categoria>();

            try
            {
                articuloDAL.setearConsulta("SELECT Id, Descripcion FROM Categorias");

                articuloDAL.ejecutarLectura();

                while (articuloDAL.Lector.Read())
                {
                    Categoria categoria = new Categoria
                    {
                        Id = Convert.ToInt32(articuloDAL.Lector["Id"]),
                        Descripcion = articuloDAL.Lector["Descripcion"].ToString()
                    };

                    listaCategorias.Add(categoria);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las categorías: " + ex.Message);
            }
            finally
            {
                articuloDAL.cerrarConexion();
            }

            return listaCategorias;
        }
        public List<Articulo> filtrar(string marca, string categoria, decimal precioInicial, decimal precioFinal)
        {
            List<Articulo> lista = new List<Articulo>();
            ArticuloDAL datos = new ArticuloDAL();

            try
            {
                string consulta = "SELECT A.Id AS ArticuloId, A.Codigo, A.Nombre, A.Descripcion AS ArticuloDescripcion, " +
                                  "M.Id AS MarcaId, M.Descripcion AS MarcaDescripcion, " +
                                  "C.Id AS CategoriaId, C.Descripcion AS CategoriaDescripcion, " +
                                  "A.ImagenUrl, A.Precio " +
                                  "FROM Articulos A " +
                                  "INNER JOIN Marcas M ON A.IdMarca = M.Id " +
                                  "INNER JOIN Categorias C ON A.IdCategoria = C.Id ";

                consulta += " WHERE 1=1 ";

                if (!string.IsNullOrEmpty(marca))
                {
                    consulta += $" AND M.Descripcion = '{marca}' ";
                }

                if (!string.IsNullOrEmpty(categoria))
                {
                    consulta += $" AND C.Descripcion = '{categoria}' ";
                }
                consulta += $" AND A.Precio BETWEEN {precioInicial} AND {precioFinal} ";

                

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo
                    {
                        Id = (int)datos.Lector["ArticuloId"],
                        Codigo = (string)datos.Lector["Codigo"],
                        Nombre = (string)datos.Lector["Nombre"],
                        Precio = (decimal)datos.Lector["Precio"],
                        Descripcion = (string)datos.Lector["ArticuloDescripcion"],
                        ImagenUrl = datos.Lector["ImagenUrl"] is DBNull ? null : (string)datos.Lector["ImagenUrl"],

                        Marca = new Marca
                        {
                            Id = (int)datos.Lector["MarcaId"],
                            Descripcion = (string)datos.Lector["MarcaDescripcion"]
                        },

                        Categoria = new Categoria
                        {
                            Id = (int)datos.Lector["CategoriaId"],
                            Descripcion = (string)datos.Lector["CategoriaDescripcion"]
                        }
                    };

                    lista.Add(aux);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el filtrado: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }





    }
}
