using UnityEngine;

public class MathProblemGeneration : MonoBehaviour
{
    public enum Tier
    {
        AdditionSubtraction,
        MultiplicationDivision,
        Algebra
    }

    public struct MathProblem
    {
        public string Question;
        public float Answer;
        public Tier ProblemTier;
    }

//call this function to get ur problem
    public MathProblem GenerateProblem(Tier tier)
    {
        switch (tier)
        {
            case Tier.AdditionSubtraction: return GenerateTier1();
            case Tier.MultiplicationDivision: return GenerateTier2();
            case Tier.Algebra: return GenerateTier3();
            default: return GenerateTier1();
        }
    }


    private MathProblem GenerateTier1()
    {
        int a = Random.Range(1, 10);
        int b = Random.Range(1, 10);
        bool add = Random.value > 0.5f;

        if (!add && b > a)
        {
            int tmp = a; a = b; b = tmp;
        }

        string op       = add ? "+" : "-";
        float  answer   = add ? a + b : a - b;

        return new MathProblem
        {
            Question = $"{a} {op} {b} = ?",
            Answer = answer,
            ProblemTier = Tier.AdditionSubtraction
        };
    }

    private MathProblem GenerateTier2()
    {
        int a = Random.Range(2, 13);
        int b = Random.Range(2, 13);
        bool mul = Random.value > 0.5f;

        string question;
        float  answer;

        if (mul)
        {
            question = $"{a} x {b} = ?";
            answer = a * b;
        }
        else
        {
            int product = a * b;
            question = $"{product} ÷ {a} = ?";
            answer = b;
        }

        return new MathProblem
        {
            Question = question,
            Answer = answer,
            ProblemTier = Tier.MultiplicationDivision
        };
    }

    private MathProblem GenerateTier3()
    {
        int form = Random.Range(0, 4);
        string question;
        float answer;

        switch (form)
        {
            case 0:
            {
                int x = Random.Range(1, 21);
                int b = Random.Range(1, 11);
                int c = x + b;
                question = $"x + {b} = {c}";
                answer = x;
                break;
            }
            case 1:
            {
                int b = Random.Range(1, 11);
                int x = Random.Range(b, b + 20);
                int c = x - b;
                question = $"x - {b} = {c}";
                answer = x;
                break;
            }
            case 2:
            {
                int a = Random.Range(2, 11);
                int x = Random.Range(1, 11);
                int c = a * x;
                question = $"{a}x = {c}";
                answer   = x;
                break;
            }
            default:
            {
                int a = Random.Range(2, 6);
                int x = Random.Range(1, 11);
                int b = Random.Range(1, 11);
                int c = a * x + b;
                question = $"{a}x + {b} = {c}";
                answer = x;
                break;
            }
        }

        return new MathProblem
        {
            Question = question,
            Answer = answer,
            ProblemTier = Tier.Algebra
        };
    }
}
