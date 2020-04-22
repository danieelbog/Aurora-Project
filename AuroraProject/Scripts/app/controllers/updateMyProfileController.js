let UpdateMyProfileController = function (updateMyProfileService) {
    //START THE FUNCTION
    let initial = function () {
        $('#update-influencer').submit(function (e) {
            updateAction(e);
        });
    }
    //UPDATE PROFILE
    let updateAction = function (e) {
        //PREVENT DEFAULT
        e.preventDefault();
        //CREATE VIEWMODEL
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
        //GO TO SERVICE
        updateMyProfileService.updateMyProfile(viewModel, done, fail)
    }
    //DONE
    let done = function () {
        toastr.success("Changes Saved");
    }
    //FAIL
    let fail = function () {
        toastr.error("Failed Saving Changes");
    }

    return {
        initial: initial
    }

}(UpdateMyProfileService);


