let UpdateMyProfileService = function () {
    //UPDATE MY INFLUENCER PROFILE, VIEWMODEL-INFLUENCERDTO
    let updateMyProfile = function (viewModel, done, fail) {
        $.ajax({
            url: '/api/influencers',
            method: 'put',
            data: viewModel
        })
            .done(done)
            .fail(fail)
    }

    return {
        updateMyProfile: updateMyProfile
    }
}();