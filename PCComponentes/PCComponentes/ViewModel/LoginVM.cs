using PCComponentes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCComponentes.ViewModel
{
    class LoginVM : INotifyPropertyChanged
    {
        private string userName = "";
        private string userPass = "";
        private string errorMessage = "";

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                if (userName != value)
                {
                    if (value != null && value.Length <= 4)
                    {
                        userName = value;
                    }
                    OnPropertyChanged("UserName");
                }
            }
        }
        /// <summary>
        /// Contraseña del usuario.
        /// </summary>
        public string UserPass
        {
            get
            {
                return userPass;
            }
            set
            {
                if (userPass != value)
                {
                    if (value != null && value.Length <= 10)
                    {
                        userPass = value;
                    }
                    OnPropertyChanged("UserPass");
                }
            }
        }

        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                if (errorMessage != value)
                {
                    if (value != null && value.Length <= 10)
                    {
                        errorMessage = value;
                    }
                    OnPropertyChanged("ErrorMessage");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public async void Login()
        {
            if (ComprobarCamposLogin())
            {
                List<Usuario> usuarios = new List<Usuario>(await App.UsuariosRepository.GetAllUsuariosAsync());

                Usuario usuarioResultado = usuarios.SingleOrDefault(t => t.Nombre == UserName);

                if (usuarioResultado == null)
                {
                    ErrorMessage = "El usuario no existe.";
                }
                else if (usuarioResultado.Password != UserPass)
                {
                    ErrorMessage = "Contraseña incorrecta.";
                }
                else if (usuarioResultado.Tipo == "client")
                {
                    App.Current.MainPage = new ClientPage(usuarioResultado);
                }
                else if (usuarioResultado.Tipo == "vendor")
                {
                    App.Current.MainPage = new VendorPage(usuarioResultado);
                }
            }
        }

        private bool ComprobarCamposLogin()
        {
            bool correct = true;
            if (String.IsNullOrEmpty(UserName) && String.IsNullOrEmpty(UserPass))
            {
                ErrorMessage = "Debe introducir codigo de usuario y contraseña.";
                correct = false;
            }
            else if (String.IsNullOrEmpty(UserName))
            {
                ErrorMessage = "Debe introducir codigo de usuario.";
                correct = false;
            }
            else if (String.IsNullOrEmpty(UserPass))
            {
                ErrorMessage = "Debe introducir contraseña.";
                correct = false;
            }
            else
            {
                ErrorMessage = "";
            }

            return correct;
        }
    }
}
