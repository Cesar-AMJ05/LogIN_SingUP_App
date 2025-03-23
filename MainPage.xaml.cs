using Microsoft.Maui;

namespace LogIN_SingUP_App
{
    public partial class MainPage : ContentPage
    {
        //Contraseñas y Usuario de ejemplo
        string user { get; } = "user";
        string password { get; } = "password";        

        public MainPage()
        {
            InitializeComponent();
        }

        // Verifica si se ingreso una contraseña para habilitar el botton de visualizar
        private void OnPasswordTextChanged(object sender, TextChangedEventArgs e)
        {
            TogglePasswordButton.IsEnabled = !string.IsNullOrEmpty(e.NewTextValue);
        }

        //Verifica si el usuario es el correcto, en caso verdadero habilita el boton y cambia el color
        private void OnUserTextChanged(object sender, TextChangedEventArgs e)
        {
            // Obtener los colores con valores predeterminados
            var primaryColor = (Color)Application.Current.Resources["Gray900"] ?? Colors.Gray;
            var secondaryColor = (Color)Application.Current.Resources["CyberGreen"] ?? Colors.Green;

            if (TextUserEntry.Text.Equals(user, StringComparison.OrdinalIgnoreCase))
            {
                UserCheck.Text = "✔";
                LogIn_Bttn.IsEnabled = true;
                LogIn_Bttn.BackgroundColor = secondaryColor;
            }
            else
            {
                UserCheck.Text = "❔";
                LogIn_Bttn.IsEnabled = false;
                LogIn_Bttn.BackgroundColor = primaryColor;
            }
        }
        
        //Muestra la contraseña si se preciona el botton
        private void OnShowPassword(object sender, System.EventArgs e)
        {               
                PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
                TogglePasswordButton.Text = PasswordEntry.IsPassword ? "👁" : "👁‍🗨";
        }

        // Verifica si el ususario y contraseña son correctos, en caso contrario se borra la contraseña ingresada,
        // se coloca nuevamente al usuario en la casilla yse vuelve a ocultar, ademas muestra un mensaje de advertencia
        private  void OnLogInClicked(object sender, EventArgs e)
        {
            if ((PasswordEntry.Text == password) & (TextUserEntry.Text == user)) // Agrega validación de usuario si es necesario
            {
                Text_Warnings.IsVisible = false;
                //DisplayAlert("Éxito", "Inicio de sesión exitoso", "OK");
                Navigation.PushAsync(new AppMenu());
            }
            else
            {
                Text_Warnings.IsVisible = true;
                PasswordEntry.Text = null;              
                //DisplayAlert("Error", "Contraseña Incorrecta", "F");
                PasswordEntry.IsPassword = true;
                TogglePasswordButton.Text = PasswordEntry.IsPassword ? "👁" : "👁‍🗨";
                PasswordEntry.Focus();
            }
        }

        private async void OnSingUpCliked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SingUp_Page());
        }
    }

}
