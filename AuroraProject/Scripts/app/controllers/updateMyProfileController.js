let UpdateMyProfileController = function (updateMyProfileService) {

    let initial = function () {
        $('#update-influencer').submit(function (e) {
            updateAction(e);           
        });
    }

    let updateAction = function (e) {

        e.preventDefault();

        let viewModel = {};
        viewModel.InfluencerID = $('.id-text-area').val();
        viewModel.MainLanguage = $('.mainLanguage-text-area').val();
        viewModel.MainPlatform = $('.mainPlatform-text-area').val();
        viewModel.Exposure = $('.exposure-text-area').val();
        viewModel.MainTopic = $('.mainTopic-text-area').val();
        viewModel.AudienceAge = $('.audienceAge-text-area').val();
        viewModel.AudienceMainCountry = $('.audienceMainCountry-text-area').val();
        viewModel.AudienceMainState = $('.audienceMainState-text-area').val();
        viewModel.AudienceMainTrait = $('.audienceMainTrait-text-area').val();
        viewModel.AboutTheInfluencer = $('.aboutTheInfluencer-text-area').val();
        viewModel.MembershipTypeID = $('.membershipTypeID-text-area').val();

        updateMyProfileService.updateMyProfile(viewModel, done, fail)
    }

    let done = function () {
        toastr.success("Changes Saved");
    }

    let fail = function(){
        toastr.error("Failed Saving Changes");
    }

    return {
        initial: initial
    }
}(UpdateMyProfileService);


