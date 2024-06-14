using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using context.Models;
using System.Linq;

namespace RKIS25;

public partial class RegistrationWindow : Window
{
    private TextBox loginTBox;
    private TextBox passwordTBox;
    private TextBox nameTBox;
    private TextBox surnameTBox;
    private TextBox phoneNumberTBox;
    private DatePicker birthdayDPicker;


    public RegistrationWindow()
    {
        InitializeComponent();

        loginTBox = this.FindControl<TextBox>("LoginTBox");
        passwordTBox = this.FindControl<TextBox>("PasswordTBox");
        nameTBox = this.FindControl<TextBox>("NameTBox");
        surnameTBox = this.FindControl<TextBox>("SurnameTBox");
        phoneNumberTBox = this.FindControl<TextBox>("PhoneNumberTBox");
        birthdayDPicker = this.FindControl<DatePicker>("BirthdayDPicker");

#if DEBUG
        this.AttachDevTools();
#endif

    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void RegBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(loginTBox.Text) &&
            !string.IsNullOrWhiteSpace(passwordTBox.Text) &&
            !string.IsNullOrWhiteSpace(nameTBox.Text) &&
            !string.IsNullOrWhiteSpace(surnameTBox.Text) &&
            !string.IsNullOrWhiteSpace(phoneNumberTBox.Text) &&
            !string.IsNullOrWhiteSpace(birthdayDPicker.SelectedDate.ToString()))
        {
            var newUser = new usersfor25()
            {
                Login = loginTBox.Text,
                Password = passwordTBox.Text,
                Name = nameTBox.Text,
                Surname = surnameTBox.Text,
                PhoneNumber = phoneNumberTBox.Text,
                Birthdate = birthdayDPicker.SelectedDate.ToString(),
                IdRole = 1
            };
            Service.GetDbContext().Users.Add(newUser);
            Service.GetDbContext().SaveChanges();

            new MainWindow().Show();
            Close();
        }
    }


    private void BackBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        new MainWindow().Show();
        Close();
    }
}
