package com.example.octo_umbrella.activities;
import androidx.appcompat.app.AppCompatActivity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;
import com.example.octo_umbrella.R;
import com.example.octo_umbrella.models.User;
import com.example.octo_umbrella.retrofit_builders.UserBuilder;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class LoginActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
    }

    public void Enter(View view) {
        var inputEmail = ((EditText) findViewById(R.id.login_ed_email)).getText().toString();
        var inputPassword = ((EditText) findViewById(R.id.login_ed_password)).getText().toString();

        var callback = new Callback<User>() {
            @Override
            public void onResponse(Call<User> call, Response<User> response) {
                var user = response.body();

                if(response.isSuccessful() && response.body() != null){
                    SwitchActivity(NotesActivity.class);
                }else{
                    Toast.makeText(LoginActivity.this,
                            "Email e/ou incorretos(as). Tente novamente",
                            Toast.LENGTH_SHORT
                    ).show();
                }
            }

            @Override
            public void onFailure(Call<User> call, Throwable t) {
                System.out.println(t.toString());
                Toast.makeText(LoginActivity.this,
                        "Infelizmente não foi possivel fazer login. Tente novamente",
                        Toast.LENGTH_SHORT
                ).show();
            }
        };

        UserBuilder.criar().Login(new User(inputEmail, inputPassword)).enqueue(callback);
    }

    public void CreateAccount(View view) {
        SwitchActivity(SignupActivity.class);
    }

    public void SwitchActivity(Class class1) {
        Intent i = new Intent(LoginActivity.this, class1);
        startActivity(i);
    }
}