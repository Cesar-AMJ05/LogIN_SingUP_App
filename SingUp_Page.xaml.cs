namespace LogIN_SingUP_App
{

    public partial class SingUp_Page : ContentPage
    {
        private bool flag_name_size { get; set; } = false;
        private bool flag_size { get; set; } = false;
        private bool flag_Uper { get; set; } = false;
        private bool flag_Minor { get; set; } = false;
        private bool flag_number { get; set; } = false;
        private bool flag_specialchar { get; set; } = false;

        private bool flag_is_same_pass { get; set; } = false;

        public SingUp_Page()
        {
            InitializeComponent();
        }


        private void OnNewUserEnty(object sender, TextChangedEventArgs e)
        {
            var color_true = (Color)Application.Current.Resources["Flourecnt_Vendereti"] ?? Colors.Green;
            var color_false = (Color)Application.Current.Resources["CyberReed"] ?? Colors.Red;

            //Verificamos el tamaño del nuevo usuario 
            flag_name_size = NewTextUserEntry.Text.Length > 8;
            //Cambiamo el indicador visual
            NewUserCheck.Text = flag_name_size ? "✔" : "❔";
            //Cambiamos el indicador textual
            NewUserCheck.TextColor = flag_name_size ? color_true : color_false;
            Size_Name_Flag.IsVisible = !flag_name_size;

        }

        private void OnNewPasswordTextChanged(object sender, TextChangedEventArgs e)
        {
            string temp_password = NewPasswordEntry.Text;
            var color_true = (Color)Application.Current.Resources["Flourecnt_Vendereti"] ?? Colors.Green;
            var color_false = (Color)Application.Current.Resources["CyberReed"] ?? Colors.Red;

            //Verificamos el tamaño de la contraseña
            flag_size = temp_password.Length >= 8;
            Restriccion_Length.TextColor = temp_password.Length >= 8 ? color_true : color_false;

            //Verificamos si tiene un caracter mayuscula y minuscula
            flag_Uper = temp_password.Any(char.IsUpper);
            flag_Minor = temp_password.Any(char.IsLower);
            Restriccion_UperLower.TextColor = (flag_Minor && flag_Uper) ? color_true : color_false;

            //Verificamos si contiene un numero
            flag_number = temp_password.Any(char.IsDigit);
            Restricction_Number.TextColor = flag_number ? color_true : color_false;

            //Verificamos si tiene algun caracter especial
            flag_specialchar = temp_password.Any(ch => !char.IsLetterOrDigit(ch));
            Restricction_SpecialChar.TextColor = flag_specialchar ? color_true : color_false;
        }

        private void OnSeePasswordCliked(object sender, System.EventArgs e)
        {
            NewPasswordEntry.IsPassword = !NewPasswordEntry.IsPassword;
            ToggleNewPasswordButton.Text = NewPasswordEntry.IsPassword ? "👁" : "👁‍🗨";
        }

        private void TextChangedConfirmPassword(object sender, TextChangedEventArgs e)
        {
            var color_true = (Color)Application.Current.Resources["Flourecnt_Vendereti"] ?? Colors.Green;
            var color_false = (Color)Application.Current.Resources["CyberReed"] ?? Colors.Red;
            var color_active = (Color)Application.Current.Resources["CyberGreen"] ?? Colors.Green;
            var color_desactive = (Color)Application.Current.Resources["Gray900"] ?? Colors.Gray;

            flag_is_same_pass = (ConfirmPasswordEntry.Text == NewPasswordEntry.Text);

            Text_Warnings.IsVisible = !flag_is_same_pass;

            ConfirmPasswordCheck.Text = flag_is_same_pass ? "✔" : "❔";
            ConfirmPasswordCheck.TextColor = flag_is_same_pass ? color_true : color_false;
            SingUp_Bttn.IsEnabled = flag_is_same_pass;
            SingUp_Bttn.BackgroundColor = flag_is_same_pass ? color_active : color_desactive;
        }

        private async void OnSingupBttnClikedtwo(object sender, System.EventArgs E)
        {
            if (flag_is_same_pass && flag_specialchar && flag_Minor && flag_number && flag_size && flag_name_size)
            {
                _ = DisplayAlert("SingUp...", "Registro correcto", "✔");

                // Navegar a la MainPage después de un registro exitoso
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                _ = DisplayAlert("SingUp...", "Error durante el registro", "✔");
            }
        }

        private async void Cancel_Bttn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}
