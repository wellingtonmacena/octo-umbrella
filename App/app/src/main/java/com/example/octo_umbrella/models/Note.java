package com.example.octo_umbrella.models;

import com.google.gson.annotations.SerializedName;

public class Note {
    @SerializedName("id")
    public String Id;
    @SerializedName("userEmail")
    public String UserEmail;
    @SerializedName("title")
    public String Title;
    @SerializedName("content")
    public String Content;
    @SerializedName("createdDate")
    public String CreatedDate ;
    @SerializedName("lastModifiedDate")
    public String LastModifiedDate  ;
}
