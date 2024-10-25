//*****************************************************************************
//** 1233. Remove Sub-Folders from the Filesystem    leetcode                **
//*****************************************************************************


/**
 * Note: The returned array must be malloced, assume caller calls free().
 */
// Helper function to compare strings by length
int compareByLength(const void* a, const void* b) {
    return strlen(*(const char**)a) - strlen(*(const char**)b);
}

char** removeSubfolders(char** folder, int folderSize, int* returnSize) {
    // Sort folders by length
    qsort(folder, folderSize, sizeof(char*), compareByLength);

    // Initialize the result array with a maximum size equal to folderSize
    char** res = (char**)malloc(folderSize * sizeof(char*));
    *returnSize = 0;

    for (int i = 0; i < folderSize; ++i) {
        bool isSubfolder = false;
        for (int j = 0; j < *returnSize; ++j) {
            int len = strlen(res[j]);
            // Check if current folder starts with a previously added folder path and has '/' after it
            if (strncmp(folder[i], res[j], len) == 0 && folder[i][len] == '/') {
                isSubfolder = true;
                break;
            }
        }
        if (!isSubfolder) {
            res[*returnSize] = folder[i];
            (*returnSize)++;
        }
    }

    // Resize result array to fit only the number of elements in it
    res = realloc(res, *returnSize * sizeof(char*));
    return res;
}