using Jaunts.Portal.Web.Client.Models.Colors;
using Jaunts.Portal.Web.Client.Models.ContainerComponents;
using Jaunts.Portal.Web.Client.Models.IdentityComponents.Exceptions;
using Jaunts.Portal.Web.Client.Models.IdentityViews;
using Jaunts.Portal.Web.Client.Models.IdentityViews.Exceptions;
using Jaunts.Portal.Web.Client.Services.Views.IdentityViews;
using Jaunts.Portal.Web.Client.Views.Bases;
using Microsoft.AspNetCore.Components;

namespace Jaunts.Portal.Web.Views.Components.IdentityComponents
{
    public partial class SignUpComponent : ComponentBase
    {
        [Inject]
        public IIdentityViewService IdentityViewService { get; set; }

        public ComponentState State { get; set; }
        public IdentityComponentException Exception { get; set; }
        public SignUpView SignUpView { get; set; }
        public TextBoxBase SignUpEmailTextBox { get; set; }
        public TextBoxBase SignUpFirstNameTextBox { get; set; }
        public TextBoxBase SignUpLastNameTextBox { get; set; }
        public TextBoxBase SignUpPhoneNumberTextBox { get; set; }
        public TextBoxBase SignUpUserNameTextBox { get; set; }
        public TextBoxBase SignUpPasswordTextBox { get; set; }
        public TextBoxBase SignUpPasswordRetypeTextBox { get; set; }
        public ButtonBase SubmitButton { get; set; }
        public SpinnerBase Spinner { get; set; }

        protected override void OnInitialized()
        {
            SignUpView = new SignUpView();
            State = ComponentState.Content;
        }

        public async void SignUpAsync()
        {
            try
            {
                ApplySubmittingStatus();
                await IdentityViewService.RegisterUserAsync(SignUpView);
                NavigateToRideSubmittedPage();
            }
            catch (IdentityViewValidationException identityViewValidationException)
            {
                string validationMessage =
                    identityViewValidationException.InnerException.Message;

                ApplySubmissionFailed(validationMessage);
            }
            catch (IdentityViewDependencyValidationException dependencyValidationException)
            {
                string validationMessage =
                    dependencyValidationException.InnerException.Message;

                ApplySubmissionFailed(validationMessage);
            }
            catch (IdentityViewDependencyException identityViewDependencyException)
            {
                string validationMessage =
                    identityViewDependencyException.Message;

                ApplySubmissionFailed(validationMessage);
            }
            catch (IdentityViewServiceException identityViewServiceException)
            {
                string validationMessage =
                    identityViewServiceException.Message;

                ApplySubmissionFailed(validationMessage);
            }
        }

        private void ApplySubmittingStatus()
        {
            Spinner.Show();
            SignUpEmailTextBox.Disable();
            SignUpUserNameTextBox.Disable();
            SignUpFirstNameTextBox.Disable();
            SignUpLastNameTextBox.Disable();
            SignUpPhoneNumberTextBox.Disable();
            SignUpPasswordTextBox.Disable();
            SignUpPasswordRetypeTextBox.Disable();
            SubmitButton.Disable();
        }

        private void NavigateToRideSubmittedPage() =>
            IdentityViewService.NavigateTo("/submit");

        private void ApplySubmissionFailed(string errorMessage)
        {
            Spinner.Hide();
            SignUpEmailTextBox.Enable();
            SignUpUserNameTextBox.Enable();
            SignUpFirstNameTextBox.Enable();
            SignUpLastNameTextBox.Enable();
            SignUpPhoneNumberTextBox.Enable();
            SignUpPasswordTextBox.Enable();
            SignUpPasswordRetypeTextBox.Enable();
            SubmitButton.Enable();
        }
    }
}

