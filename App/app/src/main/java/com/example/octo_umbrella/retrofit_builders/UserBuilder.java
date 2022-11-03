package com.example.octo_umbrella.retrofit_builders;

import com.example.octo_umbrella.interfaces.endpoints.IUser;

import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class UserBuilder {
    public static IUser criar() {
        var retrofit = new Retrofit.Builder()
                .baseUrl("https://octo-umbrella-api.herokuapp.com")
                .addConverterFactory(GsonConverterFactory.create())
                .build();

        var api = retrofit.create(IUser.class);

        return api;
    }
}
