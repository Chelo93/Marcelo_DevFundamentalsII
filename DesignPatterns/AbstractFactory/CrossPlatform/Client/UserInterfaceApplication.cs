using CrossPlatform.Interfaces;

namespace CrossPlatform.Client;

// Enhanced client for user interface creation
public class UserInterfaceApplication(
  IUserInterfaceComponentFactory uiFactory)
{
  private readonly IUserInterfaceComponentFactory _uiFactory = uiFactory ?? throw new ArgumentNullException(nameof(uiFactory));
  private readonly List<IButton> _buttons = [];
  private readonly List<ITextBox> _textBoxes = [];
  private readonly List<ICheckBox> _checkBoxes = [];

  public void CreateLoginForm()
  {
    // Create username field
    var usernameTextBox = _uiFactory.CreateTextBox();
    usernameTextBox.SetText("Enter username");
    usernameTextBox.Render();
    _textBoxes.Add(usernameTextBox);

    // Create password field
    var passwordTextBox = _uiFactory.CreateTextBox();
    passwordTextBox.SetText("********");
    passwordTextBox.Render();
    _textBoxes.Add(passwordTextBox);

    // Create remember me checkbox
    var rememberMeCheckBox = _uiFactory.CreateCheckBox();
    rememberMeCheckBox.Check(false);
    rememberMeCheckBox.Render();
    _checkBoxes.Add(rememberMeCheckBox);

    // Create login button
    var loginButton = _uiFactory.CreateButton();
    loginButton.Render();
    _buttons.Add(loginButton);

    Console.WriteLine("Login form created successfully");
  }

  public void CreateRegistrationForm()
  {
    // Create email field
    var emailTextBox = _uiFactory.CreateTextBox();
    emailTextBox.SetText("Enter email");
    emailTextBox.Render();
    _textBoxes.Add(emailTextBox);

    // Create username field
    var usernameTextBox = _uiFactory.CreateTextBox();
    usernameTextBox.SetText("Choose username");
    usernameTextBox.Render();
    _textBoxes.Add(usernameTextBox);

    // Create password field
    var passwordTextBox = _uiFactory.CreateTextBox();
    passwordTextBox.SetText("Create password");
    passwordTextBox.Render();
    _textBoxes.Add(passwordTextBox);

    // Create terms and conditions checkbox
    var termsCheckBox = _uiFactory.CreateCheckBox();
    termsCheckBox.Check(false);
    termsCheckBox.Render();
    _checkBoxes.Add(termsCheckBox);

    // Create register button
    var registerButton = _uiFactory.CreateButton();
    registerButton.Render();
    _buttons.Add(registerButton);

    Console.WriteLine("Registration form created successfully");
  }
}