using Jaunts.Portal.Web.Client.Models.Colors;
using Jaunts.Portal.Web.Client.Models.ContainerComponents;
using Jaunts.Portal.Web.Client.Models.IdentityViews;
using Jaunts.Portal.Web.Client.Models.IdentityViews.Exceptions;
using Jaunts.Portal.Web.Client.Models.RideRegistrationComponents.Exceptions;
using Jaunts.Portal.Web.Client.Services.Views.IdentityViews;
using Jaunts.Portal.Web.Client.Views.Bases;
using Microsoft.AspNetCore.Components;

namespace Jaunts.Portal.Web.Views.Components.IdentityComponents
{
    public partial class ResetPasswordComponent
    {
        [Inject]
        public IIdentityViewService IdentityViewService { get; set; }

        public ComponentState State { get; set; }
        public RideRegistrationComponentException Exception { get; set; }
        public ResetPasswordView ResetPasswordView { get; set; }
        public bool status { get; set; } = false;

        [SupplyParameterFromQuery]
        public string EmailToken { get; set; }

        [SupplyParameterFromQuery]
        public string Email { get; set; }
        public TextBoxBase ResetPasswordEmailTextBox { get; set; } 
        public TextBoxBase ResetPasswordPasswordTextBox { get; set; }
        public TextBoxBase ResetPasswordConfirmPasswordTextBox { get; set; }
        public ButtonBase SubmitButton { get; set; }
        public SpinnerBase Spinner { get; set; }

        protected override void OnInitialized()
        {
            ResetPasswordView = new ResetPasswordView();
            State = ComponentState.Content;
        }

        public async void ResetPasswordAsync()
        {
           
            try
            {
                ResetPasswordView.Email = Email;
                ResetPasswordView.Token = EmailToken;
                ApplySubmittingStatus();
                status = await IdentityViewService.ResetPasswordAsync(ResetPasswordView);
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
            ResetPasswordEmailTextBox.Disable();
            ResetPasswordPasswordTextBox.Disable();
            ResetPasswordPasswordTextBox.Disable();
            ResetPasswordConfirmPasswordTextBox.Disable();
            SubmitButton.Disable();
        }

        private void NavigateToRideSubmittedPage() =>
            IdentityViewService.NavigateTo("/message");

        private void ApplySubmissionFailed(string errorMessage)
        {
            Spinner.Hide();
            ResetPasswordEmailTextBox.Enable();
            ResetPasswordPasswordTextBox.Enable();
            ResetPasswordPasswordTextBox.Enable();
            ResetPasswordConfirmPasswordTextBox.Enable();
            SubmitButton.Enable();
        }
    }
}

