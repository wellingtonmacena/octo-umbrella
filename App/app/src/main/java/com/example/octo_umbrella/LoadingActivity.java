package com.example.octo_umbrella;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;

public class LoadingActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.loading_activity);

        var runnable = new Runnable() {
            @Override
            public void run() {
                Intent i = new Intent(LoadingActivity.this, InitialPage.class);
                startActivity(i);
                finish();
            }
        };

        var handlerThread = new Handler();
        handlerThread.postDelayed(runnable, 500);
    }
}