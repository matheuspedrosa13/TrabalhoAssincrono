export const Endpoints = {
    authentication: {
        login: `https://trabalhoassincrono-3.onrender.com/api/TrabalhoAsync/Login/`, //email and password (GET)
        logout: `https://trabalhoassincrono-3.onrender.com/api/TrabalhoAsync/Logout/` //email (GET)
    },
    userInfo: {
        getUser: `https://trabalhoassincrono-3.onrender.com/api/TrabalhoAsync/GetUser/`, //email (GET)   
    },
    relationShip: {
        createRelationship: `https://trabalhoassincrono-3.onrender.com/api/TrabalhoAsync/CreateRelationship/` /*  emailMainUser / emailAddedUser  (PUT)*/,
        removeRelationship: `https://trabalhoassincrono-3.onrender.com/api/TrabalhoAsync/RemoveRelationship/` /* emailMainUser / emailRemoveUser (PUT)*/,
        recommendationUser: `https://trabalhoassincrono-3.onrender.com/api/TrabalhoAsync/RecommendationUser/` /* emailMainUser (GET)*/
    }
} 