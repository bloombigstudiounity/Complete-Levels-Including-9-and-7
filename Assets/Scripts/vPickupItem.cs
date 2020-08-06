using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//namespace Invector
//{
public class vPickupItem : MonoBehaviour
    {
        AudioSource _audioSource;
        public AudioClip _audioClip;
        public GameObject _particle;
        public enum PickUpType {
            Spray,
            PaperRoll,
            Tape,
            Food
        }
        public PickUpType pickUpType;

        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals("Player") && !_audioSource.isPlaying)
            {
            CollectablesCount.CollectableCount++;
                Renderer[] renderers = GetComponentsInChildren<Renderer>();
                foreach (Renderer r in renderers)
                    r.enabled = false;

                _audioSource.PlayOneShot(_audioClip);
                if (_particle)
                    Instantiate(_particle, other.transform.position, other.transform.rotation);

            if (pickUpType == PickUpType.Food)
            {
                LevelManager.currentFoodIndex++;
            }
            else if (pickUpType == PickUpType.Tape)
            {
                LevelManager.currentTapeIndex++;

            }
            else if (pickUpType == PickUpType.Spray)
            {
                LevelManager.currentSprayIndex++;

            }
            else if (pickUpType == PickUpType.PaperRoll)
            {
                LevelManager.currentRollsIndex++;

            }
            UIManager.Instance.UpdateUI();
            if (LevelManager.Instance.IsLevelComplete())
                LevelManager.Instance.LevelCompleteTrigger.SetActive(true);
            else
                LevelManager.Instance.LevelCompleteTrigger.SetActive(false);
            Destroy(gameObject, _audioClip.length);
                
            }
        }
    }
//}
