using Microsoft.Maui;

namespace ContraJudia
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // Evento para mostrar/ocultar la contraseña
        private void OnTogglePasswordButtonClicked(object sender, System.EventArgs e)
        {
            PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
            TogglePasswordButton.Text = PasswordEntry.IsPassword ? "👁" : "👁‍🗨";
        }

        // Evento para borrar los campos
        private void OnClearButtonClicked(object sender, System.EventArgs e)
        {
            PasswordEntry.Text = string.Empty;
            UserEntry.Text = string.Empty;
        }

        // Evento para manejar el inicio de sesión
        private void OnLoginButtonClicked(object sender, System.EventArgs e)
        {
            // Aquí puedes agregar la lógica de validación
            string usuario = "admin"; // Reemplaza con el valor real
            string contraseña = "heilhitler"; // Reemplaza con el valor real

            if ((PasswordEntry.Text == contraseña) & (UserEntry.Text == usuario)) // Agrega validación de usuario si es necesario
            {
                ErrorMessageLabel.IsVisible = false;
                DisplayAlert("Éxito", "Inicio de sesión exitoso", "OK");
            }
            else
            {
                PasswordEntry.Text = string.Empty;
                ErrorMessageLabel.IsVisible = true;
                PasswordEntry.IsPassword = true;
                TogglePasswordButton.Text = "👁";
            }
        }

        // Evento para navegar a la pantalla de SignUp
        private async void OnSignUpButtonClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }
    }
}