using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextTextButton : MonoBehaviour {
 
    // Set up in inspector
    public Text showingText;

    private string[] lines;
    private int position;
    private bool isDone;

    public void Start()
    {
        lines = new string[] {
            "아무래도 좆됐다",
            "아무리 생각해도 그것밖에 생각나지 않는다",
            "블랙홀이 지구를 집어 삼키고 있다",
            "모든 탈출 시도는 실패했다",
            "더 이상 이 행성에 인간은 없다",
            "나밖에는",
            "이 지옥같은 행성에서 벗어나야 한다"
        };
        position = 0;
        isDone = false;
        printLetters(lines[position]);
    }

    // load scene
    public void onClick() {
        if (!isDone) {
            printLetters(lines[++position]);
            if (position + 1 == lines.Length)
                isDone = true;
        }
        else
            SceneManager.LoadScene(1);
    }

    public void printLetters(string letters) {
        showingText.text = letters;
    }
}
