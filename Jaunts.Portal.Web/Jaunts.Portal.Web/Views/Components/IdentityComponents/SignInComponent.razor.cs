using Jaunts.Portal.Web.Client.Models.Colors;
using Jaunts.Portal.Web.Client.Models.ContainerComponents;
using Jaunts.Portal.Web.Client.Models.IdentityViews;
using Jaunts.Portal.Web.Client.Models.IdentityViews.Exceptions;
using Jaunts.Portal.Web.Client.Models.IdentityComponents.Exceptions;
using Jaunts.Portal.Web.Client.Services.Views.IdentityViews;
using Jaunts.Portal.Web.Client.Views.Bases;
using Microsoft.AspNetCore.Components;

namespace Jaunts.Portal.Web.Views.Components.IdentityComponents
{
    public partial class SignInComponent : ComponentBase
    {

        [Inject]
        public IIdentityViewService IdentityViewService { get; set; }

        public ComponentState State { get; set; }
        public IdentityComponentException Exception { get; set; }
        public SignInView SignInView { get; set; }
        public TextBoxBase SignInEmailTextBox { get; set; }
        public TextBoxBase SignInPasswordTextBox { get; set; }
        public ButtonBase SubmitButton { get; set; }
        public SpinnerBase Spinner { get; set; }

        protected override void OnInitialized()
        {
            SignInView = new SignInView();
            State = ComponentState.Content;
        }

        public async void SignInAsync()
        {
            try
            {
                ApplySubmittingStatus();
                await IdentityViewService.LogInAsync(SignInView);
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
            this.Spinner.Show();
            SignInEmailTextBox.Disable();
            SignInPasswordTextBox.Disable();
            SubmitButton.Disable();
        }

        private void NavigateToRideSubmittedPage() =>
            IdentityViewService.NavigateTo("/submit");

        private void ApplySubmissionFailed(string errorMessage)
        {
            this.Spinner.Hide();
            SignInEmailTextBox.Enable();
            SignInPasswordTextBox.Enable();
            SubmitButton.Enable();
			SubmitButton.Show();
		}
    }
}

