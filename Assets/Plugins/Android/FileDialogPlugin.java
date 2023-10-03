package FileDialog;

import android.app.Activity;
import android.content.Intent;
import android.net.Uri;

public class FileDialogPlugin {
    private static final int FILE_SELECT_CODE = 0;

    public static void OpenFileDialog(Activity activity) {
        Intent intent = new Intent(Intent.ACTION_GET_CONTENT);
        intent.setType("application/octet-stream");
        intent.addCategory(Intent.CATEGORY_OPENABLE);
        activity.startActivityForResult(Intent.createChooser(intent, "Select a File"), FILE_SELECT_CODE);
    }
}
