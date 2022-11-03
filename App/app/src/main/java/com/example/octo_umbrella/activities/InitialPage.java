package com.example.octo_umbrella.activities;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;

import com.example.octo_umbrella.R;

public class InitialPage extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_initial_page);
    }

    public void GoToSignUpPage(View view) {
        Intent i = new Intent(InitialPage.this, SignupActivity.class);
        startActivity(i);
    }

    public void GoToLoginPage(View view) {
        Intent i = new Intent(InitialPage.this, LoginActivity.class);
        startActivity(i);
    }
}