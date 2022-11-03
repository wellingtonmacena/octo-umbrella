package com.example.octo_umbrella.interfaces.endpoints;

import com.example.octo_umbrella.models.User;
import java.util.List;
import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.Path;

public interface IUser {

    @GET("user")
    public Call<List<User>> GetAllUsers();

    @GET("user/{id}")
    public Call<User> GetUser(@Path("posicaoSolicitante") String id);

    @POST("user/login")
    public Call<User> Login(@Body User user);

}
