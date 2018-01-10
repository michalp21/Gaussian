using System;

public class Gaussian {
    private static Random rnd = new Random();

    public static double NextGaussian(double mean = 0, double sd = 1, string mode = "m") {
        if (mode == "m")
            return NextGaussianMarsaglia();
        else if (mode == "bm")
            return NextGaussianBoxMuller();
        else {
            Console.WriteLine("Invalid mode");
            return;
        }
    }
    private static double NextGaussianBoxMuller(){
        double u1 = rnd.NextDouble();
        double u2 = rnd.NextDouble();
        double r = Math.sqrt (-Math.log (u1));
        double theta = 2 * Math.PI * u2;
        return r*Math.cos(theta);
    }

    private static double NextGaussianMarsaglia(){
        float v1, v2, s;
        v1 = v2 = s = 0;
        do {
            v1 = 2.0f * Random.NextDouble() - 1.0f;
            v2 = 2.0f * Random.NextDouble() - 1.0f;
            s = v1 * v1 + v2 * v2;
        } while (s >= 1.0f || s == 0f);

        s = Mathf.Sqrt((-2.0f * Mathf.Log(s)) / s);

        return v1 * s;
    }
}
