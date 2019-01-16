using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class PictureManager : MonoBehaviour {

    public enum SeekDirection { Forward, Backward }

    public Image holder;
    public Text output;

    [SerializeField]
    [HideInInspector]
    private int currentIndex = 0;

    List<Sprite> images = new List<Sprite>();
    Object[] myPics;

    void Start () {
        if (holder == null)
        {
            holder = gameObject.AddComponent<Image>();
        }
    }

    public void Seek(bool dir)
    {
        SeekDirection d = SeekDirection.Forward;
        if (dir == true)
        { d = SeekDirection.Forward; }
        else if (dir == false) { d = SeekDirection.Backward; }

        if (d == SeekDirection.Forward)
        {
            currentIndex = currentIndex + 1;
            if (currentIndex == images.Count)
            {
                currentIndex = 0;
            }
            holder.sprite = images[currentIndex];
            if (!output.text.Contains(holder.sprite.name))
            {
                output.text += System.Environment.NewLine + (currentIndex + 1) + "." + holder.sprite.name;
            }
        }
        else
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = images.Count - 1;
            }
            holder.sprite = images[currentIndex];
            if (!output.text.Contains(holder.sprite.name))
            {
                output.text += System.Environment.NewLine + (currentIndex + 1) + "." + holder.sprite.name;
            }
        }
    }

    public void LoadImages(string group)
    {
        output.text = group;
        myPics = Resources.LoadAll("Pictures/" + group,typeof(Sprite));
        images = myPics.Select(i => i as Sprite).ToList();
        currentIndex = 0;
        holder.sprite = images[currentIndex];
        output.text += System.Environment.NewLine + (currentIndex + 1) + "." + holder.sprite.name;
    }

    public void ReturnToMain()
    {
        GameControl.control.LoadScene("menu");
    }
}
