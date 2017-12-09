using PCComponentes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCComponentes.ViewModel
{
    class VendorVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region atributos
        //Mensaje de bienvenida
        private String mensajeBienvenida;
        //Usuario actual
        private Usuario usuario;
        //Lista de pedidos
        private List<ListaPedidoItem> listaPedidos;
        #endregion

        #region propiedades
        public VendorVM(Usuario usuario)
        {
            this.usuario = usuario;
            InicializarValores();
        }

        public string MensajeBienvenida
        {
            get
            {
                return mensajeBienvenida;
            }
            set
            {
                if (mensajeBienvenida != value)
                {
                    mensajeBienvenida = value;
                    OnPropertyChanged("MensajeBienvenida");
                }
            }
        }

        /// <summary>
        /// Lista de pedidos realizados.
        /// </summary>
        public List<ListaPedidoItem> ListaPedidos
        {
            get
            {
                return listaPedidos;
            }
            set
            {
                if (listaPedidos != value)
                {
                    listaPedidos = value;
                    OnPropertyChanged("ListaPedidos");
                }
            }
        }
        #endregion

        /// <summary>
        /// Cargamos los pedidos
        /// </summary>
        /// <remarks>Cargamos los pedidos de la base de datos y mostramos el mensaje de bienvenida</remarks>
        public async void InicializarValores()
        {
            MensajeBienvenida = String.Format("Bienvenido {0}", usuario.Nombre);

            List<Usuario> ListaUsuario = new List<Usuario>(await App.UsuariosRepository.GetAllUsuariosAsync());
            List<Producto> ListaProductos = new List<Producto>(await App.ProductosRepository.GetAllProductosAsync());
            List<Pedido> ListaPedidosId = new List<Pedido>(await App.PedidosRepository.GetAllPedidosAsync());
            List<ListaPedidoItem> ListaCompleta = new List<ListaPedidoItem>();

            foreach (Pedido pedido in ListaPedidosId)
            {
                ListaCompleta.Add(new ListaPedidoItem()
                {
                    NombreUsuario = ListaUsuario.SingleOrDefault(t => t.Id == pedido.UserId).Nombre,
                    NombrePlaca = ListaProductos.SingleOrDefault(t => t.Id == pedido.Placa).Nombre,
                    NombreMicroprocesador = ListaProductos.SingleOrDefault(t => t.Id == pedido.Micro).Nombre,
                    NombreTorre = ListaProductos.SingleOrDefault(t => t.Id == pedido.Torre).Nombre,
                    NombreMemoria = ListaProductos.SingleOrDefault(t => t.Id == pedido.Memoria).Nombre,
                    NombreTarjetaGrafica = ListaProductos.SingleOrDefault(t => t.Id == pedido.Tarjeta).Nombre,
                    PrecioPedido = ListaProductos.SingleOrDefault(t => t.Id == pedido.Placa).Precio +
                    ListaProductos.SingleOrDefault(t => t.Id == pedido.Micro).Precio +
                    ListaProductos.SingleOrDefault(t => t.Id == pedido.Torre).Precio +
                    ListaProductos.SingleOrDefault(t => t.Id == pedido.Memoria).Precio +
                    ListaProductos.SingleOrDefault(t => t.Id == pedido.Tarjeta).Precio
                }
                );
            }

            ListaPedidos = ListaCompleta;
        }

        /// <summary>
        /// Desconectar y volver a la página principal
        /// </summary>
        public void Desconectar()
        {
            App.Current.MainPage = new MainPage();
        }

    }
}
