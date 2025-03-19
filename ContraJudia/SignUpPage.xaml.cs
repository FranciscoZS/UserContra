using Microsoft.Maui;
using System.Linq;

namespace ContraJudia
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        // Evento para mostrar/ocultar la contraseña en el primer campo
        private void OnTogglePasswordButtonClicked(object sender, System.EventArgs e)
        {
            PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
            TogglePasswordButton.Text = PasswordEntry.IsPassword ? "👁" : "👁‍🗨";
        }

        // Evento para mostrar/ocultar la contraseña en el campo de confirmación
        private void OnToggleConfirmPasswordButtonClicked(object sender, System.EventArgs e)
        {
            ConfirmPasswordEntry.IsPassword = !ConfirmPasswordEntry.IsPassword;
            ToggleConfirmPasswordButton.Text = ConfirmPasswordEntry.IsPassword ? "👁" : "👁‍🗨";
        }

        // Evento para validar dinámicamente la contraseña mientras se escribe
        private void OnPasswordTextChanged(object sender, TextChangedEventArgs e)
        {
            string password = PasswordEntry.Text;

            // Validar longitud de la contraseña
            PasswordLengthLabel.TextColor = password.Length >= 8 ? Color.FromArgb("#4CAF50") : Color.FromArgb("#808080");

            // Validar letra mayúscula
            PasswordUpperLabel.TextColor = password.Any(char.IsUpper) ? Color.FromArgb("#4CAF50") : Color.FromArgb("#808080");

            // Validar letra minúscula
            PasswordLowerLabel.TextColor = password.Any(char.IsLower) ? Color.FromArgb("#4CAF50") : Color.FromArgb("#808080");

            // Validar número
            PasswordNumberLabel.TextColor = password.Any(char.IsDigit) ? Color.FromArgb("#4CAF50") : Color.FromArgb("#808080");
        }

        // Evento para manejar el registro
        private void OnSignUpButtonClicked(object sender, System.EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;
            string confirmPassword = ConfirmPasswordEntry.Text;

            // Validar que las contraseñas coincidan
            if (password != confirmPassword)
            {
                ErrorMessageLabel.Text = "Las contraseñas no coinciden.";
                ErrorMessageLabel.IsVisible = true;
                return;
            }

            // Validar que la contraseña cumpla con todos los requisitos
            if (password.Length < 8 || !password.Any(char.IsUpper) || !password.Any(char.IsLower) || !password.Any(char.IsDigit))
            {
                ErrorMessageLabel.Text = "La contraseña no cumple con los requisitos.";
                ErrorMessageLabel.IsVisible = true;
                return;
            }

            // Si todo está correcto, mostrar mensaje de éxito
            ErrorMessageLabel.IsVisible = false;
            DisplayAlert("Éxito", "Registro exitoso", "OK");
        }
    }
}