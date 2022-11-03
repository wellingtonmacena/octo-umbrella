package com.example.octo_umbrella.models;

import com.google.gson.annotations.SerializedName;

import java.util.List;

public class User {

    @SerializedName("id")
    public String Id;
    @SerializedName("fullName")
    public String FullName ;
    @SerializedName("email")
    public String Email ;
    @SerializedName("password")
    public String Password ;
    @SerializedName("createdDate")
    public String CreatedDate ;
    @SerializedName("lastModifiedDate")
    public String LastModifiedDate  ;
    @SerializedName("notes")
    public List<Note> Notes;

    public User(String id, String fullName, String email, String password, String createdDate, String lastModifiedDate, List<Note> notes) {
        Id = id;
        FullName = fullName;
        Email = email;
        Password = password;
        CreatedDate = createdDate;
        LastModifiedDate = lastModifiedDate;
        Notes = notes;
    }

    public User(String email, String password) {
        Email = email;
        Password = password;
    }
}
