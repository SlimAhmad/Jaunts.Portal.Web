using Jaunts.Portal.Web.Client.Models.Colors;
using Jaunts.Portal.Web.Client.Models.ContainerComponents;
using Jaunts.Portal.Web.Client.Models.IdentityViews.Exceptions;
using Jaunts.Portal.Web.Client.Models.RideRegistrationComponents.Exceptions;
using Jaunts.Portal.Web.Client.Services.Views.IdentityViews;
using Jaunts.Portal.Web.Client.Views.Bases;
using Microsoft.AspNetCore.Components;

namespace Jaunts.Portal.Web.Views.Components.IdentityComponents
{
    public partial class ForgotPasswordComponent
    {

        [Inject]
        public IIdentityViewService IdentityViewService { get; set; }

        public ComponentState State { get; set; }
        public RideRegistrationComponentException Exception { get; set; }
        public string ForgotPassword{ get; set; }
        public TextBoxBase ForgotPasswordEmailTextBox { get; set; }
        public ButtonBase SubmitButton { get; set; }
        public SpinnerBase Spinner { get; set; }

        protected override void OnInitialized()
        {
            ForgotPassword = string.Empty;
            State = ComponentState.Content;
        }

        public async void ForgotPasswordAsync()
        {
            try
            {
                ApplySubmittingStatus();
                await IdentityViewService.ForgotPasswordAsync(ForgotPassword);
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
            ForgotPasswordEmailTextBox.Disable();
            SubmitButton.Disable();
        }

        private void NavigateToRideSubmittedPage() =>
            IdentityViewService.NavigateTo("/forgotten/password/mail");

        private void ApplySubmissionFailed(string errorMessage)
        {
            Spinner.Hide();
            ForgotPasswordEmailTextBox.Enable();
            SubmitButton.Enable();
        }
    }
}

