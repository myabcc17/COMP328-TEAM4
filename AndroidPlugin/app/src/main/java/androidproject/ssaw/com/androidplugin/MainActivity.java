package androidproject.ssaw.com.androidplugin;

import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.ListAdapter;
import android.widget.SimpleCursorAdapter;

public class MainActivity extends AppCompatActivity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        loadDB();
    }

    @Override
    protected void onResume() {
        super.onResume();
        loadDB();
    }

    public void loadDB(){
        SQLiteDatabase db = openOrCreateDatabase(
                "result.db",
                SQLiteDatabase.CREATE_IF_NECESSARY,
                null );

        db.execSQL("CREATE TABLE IF NOT EXISTS result "
                + "(subject TEXT, high_score INTEGER);");

        Cursor c = db.rawQuery("SELECT * FROM result;", null);
        startManagingCursor(c);

        ListAdapter adapt = new SimpleCursorAdapter(
                this,
                android.R.layout.simple_list_item_2,
                c,
                new String[]{"subject", "high_score"},
                new int[]{android.R.id.text1, android.R.id.text2}, 0 );
        setListAdapter(adapt);
        if(db != null){
            db.close();
        }
    }

    private void setListAdapter(ListAdapter adapt) {
    }

    public void setInsert(String subject, int score) {


        String sql = "INSERT INTO result (subject, high_score) VALUES ('" + subject + "'," +score+");";

        SQLiteDatabase db = openOrCreateDatabase(
                "result.db",
                SQLiteDatabase.CREATE_IF_NECESSARY,
                null );

        db.execSQL(sql);

        finish(); //Call this when your activity is done and should be closed.
    }
}
