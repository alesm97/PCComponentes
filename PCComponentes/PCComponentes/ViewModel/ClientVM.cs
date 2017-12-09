using PCComponentes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PCComponentes.ViewModel
{
    class ClientVM : INotifyPropertyChanged
    {
        #region atributos
        /// <summary>
        /// Atributos
        /// </summary>
        private List<Producto> listaPlaca;
        private List<Producto> listaMicro;
        private List<Producto> listaTorre;
        private List<Producto> listaMemoria;
        private List<Producto> listaTarjetaGrafica;
        private List<Producto> pedidoActual;
        private int indicePlaca;
        private int indiceMicro;
        private int indiceTorre;
        private int indiceMemoria;
        private int indiceTarjetaGrafica;
        private String mensajeBienvenida;
        private bool estadoAceptar;
        private bool estadoConfirmar;
        private double precioTotal;
        private Usuario usuario;
        private string welcomeMessage;
        #endregion

        #region constructor
        /// <summary>
        /// Constructor del view model de la vista UserPage.
        /// </summary>
        /// <param name="usuario">Usuario actual.</param>
        public ClientVM(Usuario usuario)
        {
            this.usuario = usuario;
            InicializarValores();

        }
        #endregion

        #region propiedades
        /// <summary>
        /// Lista de placas bases.
        /// </summary>
        public List<Producto> ListaPlaca
        {
            get
            {
                return listaPlaca;
            }
            set
            {
                if (listaPlaca != value)
                {
                    listaPlaca = value;
                    OnPropertyChanged("ListaPlaca");
                }
            }
        }
        /// <summary>
        /// Lista de microprocesadores.
        /// </summary>
        public List<Producto> ListaMicro
        {
            get
            {
                return listaMicro;
            }
            set
            {
                if (listaMicro != value)
                {
                    listaMicro = value;
                    OnPropertyChanged("ListaMicro");
                }
            }
        }
        /// <summary>
        /// Lista de torres.
        /// </summary>
        public List<Producto> ListaTorre
        {
            get
            {
                return listaTorre;
            }
            set
            {
                if (listaTorre != value)
                {
                    listaTorre = value;
                    OnPropertyChanged("ListaTorre");
                }
            }
        }
        /// <summary>
        /// Lista de memorias.
        /// </summary>
        public List<Producto> ListaMemoria
        {
            get
            {
                return listaMemoria;
            }
            set
            {
                if (listaMemoria != value)
                {
                    listaMemoria = value;
                    OnPropertyChanged("ListaMemoria");
                }
            }
        }
        /// <summary>
        /// Lista de tarjetas graficas.
        /// </summary>
        public List<Producto> ListaTarjetaGrafica
        {
            get
            {
                return listaTarjetaGrafica;
            }
            set
            {
                if (listaTarjetaGrafica != value)
                {
                    listaTarjetaGrafica = value;
                    OnPropertyChanged("ListaTarjetaGrafica");
                }
            }
        }
        /// <summary>
        /// Indice acutal de placa.
        /// </summary>
        public int IndicePlaca
        {
            get
            {
                return indicePlaca;
            }
            set
            {
                if (indicePlaca != value)
                {
                    indicePlaca = value;
                    OnPropertyChanged("IndicePlaca");
                }
            }
        }
        /// <summary>
        /// Indice actual de procesador.
        /// </summary>
        public int IndiceMicro
        {
            get
            {
                return indiceMicro;
            }
            set
            {
                if (indiceMicro != value)
                {
                    indiceMicro = value;
                    OnPropertyChanged("IndiceProcesador");
                }
            }
        }
        /// <summary>
        /// Indice actual de torre.
        /// </summary>
        public int IndiceTorre
        {
            get
            {
                return indiceTorre;
            }
            set
            {
                if (indiceTorre != value)
                {
                    indiceTorre = value;
                    OnPropertyChanged("IndiceTorre");
                }
            }
        }
        /// <summary>
        /// Indice actual de memoria.
        /// </summary>
        public int IndiceMemoria
        {
            get
            {
                return indiceMemoria;
            }
            set
            {
                if (indiceMemoria != value)
                {
                    indiceMemoria = value;
                    OnPropertyChanged("IndiceMemoria");
                }
            }
        }
        /// <summary>
        /// Indice actual de tarjeta grafica
        /// </summary>
        public int IndiceTarjetaGrafica
        {
            get
            {
                return indiceTarjetaGrafica;
            }
            set
            {
                if (indiceTarjetaGrafica != value)
                {
                    indiceTarjetaGrafica = value;
                    OnPropertyChanged("IndiceTarjetaGrafica");
                }
            }
        }

        public bool EstadoAceptar
        {
            get
            {
                return estadoAceptar;
            }
            set
            {
                if (estadoAceptar != value)
                {
                    estadoAceptar = value;
                    OnPropertyChanged("EstadoAceptar");
                }
            }
        }

        public bool EstadoConfirmar
        {
            get
            {
                return estadoConfirmar;
            }
            set
            {
                if (estadoConfirmar != value)
                {
                    estadoConfirmar = value;
                    OnPropertyChanged("EstadoConfirmar");
                }
            }
        }

        public string WelcomeMessage
        {
            get
            {
                return welcomeMessage;
            }
            set
            {
                if (mensajeBienvenida != value)
                {
                    mensajeBienvenida = value;
                    OnPropertyChanged("WelcomeMessage");
                }
            }
        }

        public double PrecioTotal
        {
            get
            {
                return precioTotal;
            }
            set
            {
                if (precioTotal != value)
                {
                    precioTotal = value;
                    OnPropertyChanged("PrecioTotal");
                }
            }
        }

        public List<Producto> PedidoActual
        {
            get
            {
                return pedidoActual;
            }
            set
            {
                if (pedidoActual != value)
                {
                    pedidoActual = value;
                    OnPropertyChanged("PedidoActual");
                }
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Desconectar y volver a la página principal
        /// </summary>
        public void Desconectar()
        {
            App.Current.MainPage = new MainPage();
        }

        /// <summary>
        /// Comprueba si puede habilitar el botón
        /// </summary>
        public void ComprobarComponentes()
        {
            if (IndicePlaca != -1 &&
                IndiceMicro != -1 &&
                IndiceTorre != -1 &&
                IndiceMemoria != -1 &&
                IndiceTarjetaGrafica != -1)
            {
                EstadoAceptar = true;
                EstadoConfirmar = true;
            }
            else
            {
                EstadoAceptar = false;
                EstadoConfirmar = false;
            }
        }

        /// <summary>
        /// Agregar componente a la lista
        /// </summary>
        public void AgregarComponentes()
        {
            List<Producto> componentes = new List<Producto>();

            componentes.Add(ListaPlaca.ElementAt(IndicePlaca));
            componentes.Add(ListaMicro.ElementAt(IndiceMicro));
            componentes.Add(ListaTorre.ElementAt(IndiceTorre));
            componentes.Add(ListaMemoria.ElementAt(IndiceMemoria));
            componentes.Add(ListaTarjetaGrafica.ElementAt(IndiceTarjetaGrafica));

            PedidoActual = componentes;

            PrecioTotal = ListaPlaca.ElementAt(IndicePlaca).Precio +
            ListaMicro.ElementAt(IndiceMicro).Precio +
            ListaTorre.ElementAt(IndiceTorre).Precio +
            ListaMemoria.ElementAt(IndiceMemoria).Precio +
            ListaTarjetaGrafica.ElementAt(IndiceTarjetaGrafica).Precio;
        }

        /// <summary>
        /// Añade el pedido a la bdd y recarga la página
        /// </summary>
        /// <param name="actualPage"></param>
        public async void RealizarPedido(Page actualPage)
        {
            await App.PedidosRepository.AddNewPedidoAsync(usuario.Id,
                ListaPlaca.ElementAt(IndicePlaca).Id,
                ListaMemoria.ElementAt(IndiceMemoria).Id,
                ListaMicro.ElementAt(IndiceMicro).Id,
                ListaTorre.ElementAt(IndiceTorre).Id,
                ListaTarjetaGrafica.ElementAt(IndiceTarjetaGrafica).Id);

            await actualPage.DisplayAlert("Pedido realizado correctamente.", "", "Aceptar");
            App.Current.MainPage = new ClientPage(usuario);
        }

        /// <summary>
        /// Carga los productos
        /// </summary>
        public async void InicializarValores()
        {
            WelcomeMessage = String.Format("Bienvenido {0}", usuario.Nombre);
            ListaPlaca = new List<Producto>(await App.ProductosRepository.GetAllPlacaAsync());
            ListaMicro = new List<Producto>(await App.ProductosRepository.GetAllMicrosAsync());
            ListaTorre = new List<Producto>(await App.ProductosRepository.GetAllTorresAsync());
            ListaMemoria = new List<Producto>(await App.ProductosRepository.GetAllMemoriasAsync());
            ListaTarjetaGrafica = new List<Producto>(await App.ProductosRepository.GetAllTarjetasAsync());
            IndicePlaca = -1;
            IndiceMicro = -1;
            IndiceTorre = -1;
            IndiceMemoria = -1;
            IndiceTarjetaGrafica = -1;
        }
    }
}
